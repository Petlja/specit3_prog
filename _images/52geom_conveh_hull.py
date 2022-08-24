import math
import pygame as pg
WORLD, SCREEN, LABEL_DIR, I = 0, 1, 2, 3
X, Y = 0, 1
q = [
    [(0, 0), ( 20, 137),  'w', 0],
    [(0, 0), ( 48, 223), 'sw', 1],
    [(0, 0), ( 57, 184),  'e', 2],
    [(0, 0), ( 45,  79),  's', 3],
    [(0, 0), (103, 169),  'n', 4],
    [(0, 0), (113, 127),  'n', 5],
    [(0, 0), (133, 240),  's', 6],
    [(0, 0), (156, 102), 'se', 7],
    [(0, 0), (220,  89),  'e', 8],
    [(0, 0), (230, 182),  'e', 9]
]

for pt in q:
    pt[WORLD] = (pt[SCREEN][X], -pt[SCREEN][Y])

display_width, display_height = 400, 300

margin  = 20
x0, y0 = margin, margin
pg.init()
GREEN = pg.Color('darkgreen')
RED = pg.Color('red')
display = pg.display.set_mode((display_width, display_height))
pg.display.set_caption('Slika')
font = pg.font.SysFont("Arial", 20)
img_cnt = 0

def label_pos(pt_pos_x, pt_pos_y, pt_r, img_w, img_h, dir):
    d = {
        'n' : (pt_pos_x - img_w//2, pt_pos_y - pt_r - img_h),
        's' : (pt_pos_x - img_w//2, pt_pos_y + pt_r),
        'e' : (pt_pos_x + pt_r, pt_pos_y - img_h // 2),
        'w' : (pt_pos_x - img_w - pt_r, pt_pos_y - img_h // 2),
        'nw' : (pt_pos_x - img_w - pt_r, pt_pos_y - img_h - pt_r),
        'ne' : (pt_pos_x + pt_r, pt_pos_y - img_h - pt_r),
        'sw' : (pt_pos_x - img_w - pt_r, pt_pos_y + pt_r),
        'se' : (pt_pos_x + pt_r, pt_pos_y + pt_r)
    }
    return d.get(dir, d['se'])

def draw(stack, is_last_line_bad):
    global img_cnt
    pt_r = 5
    display.fill((255, 255, 255))
    for i, pt in enumerate(p):
        pg.draw.line(display, pg.Color('black'), p0[SCREEN], pt[SCREEN], 1)

    # pg.draw.polygon(display, pg.Color('black'), [t[SCREEN] for t in p], 3)
    pg.draw.lines(display, GREEN, False, [t[SCREEN] for t in stack], 3)
    if is_last_line_bad:
        pg.draw.line(display, RED, stack[-1][SCREEN], stack[-2][SCREEN], 3)

    for i, pt in enumerate((p0, *p)):
        txt = font.render(f"{i}", True, pg.Color("black"))
        tx, ty = label_pos(pt[SCREEN][X], pt[SCREEN][Y], pt_r, txt.get_width(), txt.get_height(), pt[LABEL_DIR])
        display.blit(txt, (int(tx), int(ty)))
        pg.draw.circle(display, pg.Color('white'), pt[SCREEN], pt_r)
        pg.draw.circle(display, pg.Color('black'), pt[SCREEN], pt_r, 1)

    img_cnt += 1
    pg.display.update()
    pg.image.save(display, f"52_geometrijski/hull_{img_cnt:02d}.png")

def turn(a, b, c):
    z = (c[1] - a[1]) * (b[0] - a[0]) - (b[1] - a[1]) * (c[0] - a[0])
    if z > 0:
        return 1
    elif z < 0:
        return -1
    else:
        return 0

p0 = min(q, key=lambda t:(t[0][1], t[0][0]))
p = []
for t in q:
    if t[0] != p0[0]:
        p.append(t)

p.sort(key=lambda t : (
        math.atan2(t[WORLD][Y]-p0[WORLD][Y], t[WORLD][X]-p0[WORLD][X]), 
        t[WORLD][Y], 
        t[WORLD][X]))

st=[]
st.append(p0)
st.append(p[0])
st.append(p[1])
draw(st, False)
for i in range(2, len(p)):
    while turn(st[-2][WORLD], st[-1][WORLD], p[i][WORLD]) <= 0:
        draw((*st, p[i]), True)
        del st[-1]
    st.append(p[i])
    draw(st, False)

draw((*st, p0), False)
pg.quit()
