import pygame as pg

WHITE, GRAY, BLACK = (255, 255, 255), (128, 128, 128), (0, 0, 0)
COLOR, PT, LABEL_DIR, NGBRS = 0, 1, 2, 3

graph1 = [
    # color, (x, y), label_dir, (ngbr0, ngbr1, ...))
    [WHITE, (191, 106), 'n', (3, 5)],
    [WHITE, (283,  68), 'n', (2, 3)],
    [WHITE, (401, 120), 'ne', (1, 3)],
    [WHITE, (423, 236), 'e', (0, 1, 2, 5)],
    [WHITE, (369, 345), 'se', (6, 8)],
    [WHITE, (227, 371), 's', (0, 3)],
    [WHITE, (126, 314), 'sw', (4, 7, 8)],
    [WHITE, (106, 221), 'w', (6, 8)],
    [WHITE, (127, 161), 'nw', (4, 6, 7)]
]
graph2 = [
    # color, (x, y), label_dir, (ngbr0, ngbr1, ...))
    [WHITE, (216,  54), 'n', (2, 3, 4)],
    [WHITE, (343,  90), 'ne', (2, )],
    [WHITE, (318, 190), 'e', (0, 1, 6)],
    [WHITE, (292, 280), 'se', (0, 4)],
    [WHITE, (210, 271), 's', (0, 3, 8)],
    [WHITE, (163, 264), 'sw', (6, 7)],
    [WHITE, ( 90, 227), 'sw', (2, 5, 7)],
    [WHITE, (103, 165), 'w', (5, 6)],
    [WHITE, (100, 110), 'nw', (4, 9)],
    [WHITE, (137,  62), 'nw', (8, )]
]

graph_a = [
    # color, (x, y), label_dir, (ngbr0, ngbr1, ...))
    [WHITE, (198, 42),   'n', (2, 5, 7)],
    [WHITE, (135, 228),  's', (5, )],
    [WHITE, (132, 131),  'e', (0, 6)],
    [WHITE, (294, 200),  's', (7, )],
    [WHITE, (197, 228),  's', (5, )],
    [WHITE, (200, 144),  'e', (0, 1, 4, 9)],
    [WHITE, ( 73, 208),  's', (2, )],
    [WHITE, (278, 117),  'w', (0, 3, 8)],
    [WHITE, (338, 172),  's', (7, )],
    [WHITE, (242, 225),  's', (5, )]
]


def set_graph(version):
    global W, H, vertices, cnt_prefix, img_cnt
    img_cnt = 0
    if version == 1: # tree
        vertices = graph_a
        cnt_prefix = "a"
        W, H = 400, 300
    elif version == 2: # general graph
        vertices = graph2
        cnt_prefix = "b"
        W, H = 500, 400


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


def draw_graph(image_prefix):
    global img_cnt
    pt_r = 10
    display.fill((255, 255, 255))
    for i, (color, pt, dir, ngbrs) in enumerate(vertices):
        for ngbr in ngbrs:
            pg.draw.line(display, pg.Color("black"), pt, vertices[ngbr][PT], 3)

    for i, (color, pt, dir, ngbrs) in enumerate(vertices):
        txt = font.render(f"{i}", True, pg.Color("black"))
        tx, ty = label_pos(pt[0], pt[1], pt_r, txt.get_width(), txt.get_height(), dir)
        display.blit(txt, (int(tx), int(ty)))
        pg.draw.circle(display, color, pt, pt_r)
        pg.draw.circle(display, pg.Color('black'), pt, pt_r, 1)

    
    img_cnt += 1
    pg.display.update()
    rect = pg.Rect(0, 0, W, H)
    sub = display.subsurface(rect)
    pg.image.save(sub, f"{image_prefix}_{cnt_prefix}{img_cnt:02d}.png")


margin  = 20
x0, y0 = margin, margin
display_width, display_height = 800, 600
pg.init()
display = pg.display.set_mode((display_width, display_height))
pg.display.set_caption('Slika')
font = pg.font.SysFont("Arial", 20)

