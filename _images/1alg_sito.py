import pygame as pg
import math

margin, r, dx, dy = 50, 10, 50, 30
prost = [True for i in range (101)]

def x_pos(br, br_txt):
    return margin + dx * ((br - 1) % r) + dx - br_txt.get_width()
    
def y_pos(br):
    return margin + dy * ((br - 1) // r)
    
def nacrtaj_sve_brojeve(n):
    for k in range (2, n+1):
        clr =  pg.Color("black") if prost[k] else pg.Color("gray")
        k_txt = font.render(f"{k}", True, clr)
        x = x_pos(k, k_txt)
        y = y_pos(k)
        display.blit(k_txt, (x, y))

def precrtaj_umnoske(k, n):
    k_txt = font.render(f"{k}", True, pg.Color("black"))
    x0 = x_pos(k, k_txt) - 2
    y0 = y_pos(k) - 2
    w1 = k_txt.get_width() + 4
    h1 = k_txt.get_height() + 4
    pg.draw.rect(display, pg.Color("black"), (x0, y0, w1, h1),  3)

    for i in range (k*k, n+1, k):
        i_txt = font.render(f"{i}", True, pg.Color("black"))
        x0 = x_pos(i, i_txt)
        y0 = y_pos(i)
        x1 = x0 + i_txt.get_width()
        y1 = y0 + i_txt.get_height()
        pg.draw.line(display, pg.Color("black"), (x0, y0), (x1, y1),  3)
        pg.draw.line(display, pg.Color("black"), (x0, y1), (x1, y0),  3)
            
pg.init()
a, b = 24, 18
display_width, display_height = 2*margin + r*dx, 2*margin + 10*dy
display = pg.display.set_mode((display_width,display_height))
pg.display.set_caption('Slika')
font = pg.font.SysFont("Arial", 20)

img_cnt = 0
n = 100
qn = math.ceil(math.sqrt(n))
for k in range (2, qn+1):
    if prost[k]:
        display.fill((255, 255, 255))
        nacrtaj_sve_brojeve(n)
        precrtaj_umnoske(k, n)
        for i in range (k*k, n+1, k):
            prost[i] = False
            
        txt = font.render(f"Прецртавање умножака за k={k}", True, pg.Color("black"))
        x = (display_width - txt.get_width()) / 2
        y = display_height - txt.get_height()
        display.blit(txt,(x, y))
        pg.display.update()
        img_cnt += 1
        pg.image.save(display, f"1_algebarski/sito_{img_cnt:02d}.png")

display.fill((255, 255, 255))
nacrtaj_sve_brojeve(n)
txt = font.render(f"Коначна табела", True, pg.Color("black"))
x = (display_width - txt.get_width()) / 2
y = display_height - txt.get_height()
display.blit(txt,(x, y))
pg.display.update()
img_cnt += 1
pg.image.save(display, f"1_algebarski/sito_{img_cnt:02d}.png")

# while pg.event.wait().type != pg.QUIT:
    # pass
pg.quit()

