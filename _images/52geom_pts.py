import os.path
import pygame as pg
display_width, display_height = 1000, 1000
pg.init()
display = pg.display.set_mode((display_width, display_height))
pg.display.set_caption('Slika')
# font = pg.font.SysFont("Arial", 20)
pt_r = 15
thickness = 5

def draw(is_polygon):
    display.fill((255, 255, 255))
    if len(pts) > 1:
        pg.draw.lines(display, pg.Color('black'), is_polygon, pts, thickness)

    for pt in pts:
        pg.draw.circle(display, pg.Color('white'), pt, pt_r)
        pg.draw.circle(display, pg.Color('black'), pt, pt_r, thickness)

    pg.display.update()  

pts = []
draw(False)
should_quit = False
while not(should_quit):
    e = pg.event.wait()
    if e.type == pg.QUIT:
        should_quit = True
    elif e.type == pg.KEYDOWN:
        if e.key == pg.K_q or e.key == pg.K_ESCAPE:
            should_quit = True
    else:
        if e.type == pg.MOUSEBUTTONDOWN:
            if e.button == 1:
                pts.append(e.pos)
                draw(False)

draw(True)
img_cnt = 1
while os.path.exists(f'img{img_cnt:02d}.png'):
    img_cnt += 1

pg.image.save(display, f'img{img_cnt:02d}.png')
pg.quit()
