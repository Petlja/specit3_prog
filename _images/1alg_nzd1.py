import pygame as pg

margin  = 50
x0, y0, unit = margin, margin, 20

def grid (w, h, step, c, th):
    xn, yn = x0 + w * unit, y0 + h * unit
    for x in range(x0, xn+1, step * unit):
        pg.draw.line(display, c, (x, y0), (x, yn), th)
    for y in range(y0, yn+1, step * unit):
        pg.draw.line(display, c, (x0, y), (xn, y), th)

def squares(w0, h0, w1, h1):
    display.fill((255, 255, 255))
    pg.draw.rect(display, pg.Color("black"), (x0, y0, w1*unit, h1*unit))
    grid(w0, h0, 1, pg.Color("gray"), 3)
    a, b, = w0, h0
    while a != w1 or b != h1:
        if a > b:
            x1 = x0 + (a-b) * unit
            pg.draw.rect(display, pg.Color("blue"), (x1, y0, b*unit, b*unit), 3)
            a -= b
        else:
            y1 = y0 + (b-a) * unit
            pg.draw.rect(display, pg.Color("blue"), (x0, y1, a*unit, a*unit), 3)
            b -= a
            
    txt = font.render(f"a={a}, b={b}", True, pg.Color("black"))
    x = (display_width - txt.get_width()) / 2
    y = display_height - txt.get_height()
    display.blit(txt,(x, y))

    pg.display.update()

pg.init()
a, b = 24, 18
display_width, display_height = 2*margin + a*unit, 2*margin + b*unit
display = pg.display.set_mode((display_width,display_height))
pg.display.set_caption('Slika')
font = pg.font.SysFont("Arial", 20)

img_cnt = 0
a1, b1 = a, b
while a1 > 0 and b1 > 0:
    squares(a, b, a1, b1)

    img_cnt += 1
    pg.image.save(display, f"1_algebarski/nzd1_{img_cnt:02d}.png")

    if a1 > b1:
        a1 -= b1
    else:
        b1 -= a1

# while pg.event.wait().type != pg.QUIT:
    # pass
pg.quit()

