import pygame as pg

margin  = 50
x0, y0, unit = margin, margin, 20
def grid (w, h, step, c, th):
    xn, yn = x0 + w * unit, y0 + h * unit
    for x in range(x0, xn+1, step * unit):
        pg.draw.line(display, c, (x, y0), (x, yn), th)
    for y in range(y0, yn+1, step * unit):
        pg.draw.line(display, c, (x0, y), (xn, y), th)


pg.init()
a, b = 24, 18
display_width, display_height = 2*margin + a*unit, 2*margin + b*unit
display = pg.display.set_mode((display_width,display_height))
pg.display.set_caption('Slika')
font = pg.font.SysFont("Arial", 20)


img_cnt = 0
for n in range (18, 5, -1):
    display.fill((255, 255, 255))
    grid(a, b, 1, pg.Color("gray"), 3)
    grid(a, b, n, pg.Color("black"), 3)
    
    txt = font.render(f"d={n}", True, pg.Color("black"))
    x = (display_width - txt.get_width()) / 2
    y = display_height - txt.get_height()
    display.blit(txt,(x, y))
    
    pg.display.update()
    img_cnt += 1
    pg.image.save(display, f"1_algebarski/nzd0_{img_cnt:02d}.png")


# while pg.event.wait().type != pg.QUIT:
    # pass
pg.quit()

