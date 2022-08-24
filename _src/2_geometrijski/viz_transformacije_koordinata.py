import math
import pygame as pg

X, Y = 0, 1

pg.init()

pg.display.set_caption("Трансформације координата")
(W, H) = (600, 400)
canvas = pg.display.set_mode((W, H))

ScalingX = 50.0
ScalingY = 50.0
TranslationX = 20.0
TranslationY = 580.0
GridDragX0 = -1
GridDragY0 = -1
IsDraggingGrid = False
fontSize = 25
ex, ey = 0, 0 # mouse position
message = ''

def WorldToScreen(xw, yw):
    xs = xw * ScalingX + TranslationX
    ys = -yw * ScalingY + TranslationY
    return (xs, ys)

def ScreenToWorld(xs, ys):
    xw = (xs - TranslationX) / ScalingX
    yw = (ys - TranslationY) / -ScalingY
    return (xw, yw)

def DrawText(s, x, y, color):
    font = pg.font.SysFont("Arial", int(fontSize))
    txt = font.render(s, True, color)
    # tw, th = (txt.get_width(), txt.get_height())
    # x, y = (x - tw * (x / W), y - th * (y / H))
    canvas.blit(txt, (x, y))

def Draw():
    canvas.fill(pg.Color("white"))

    # compute important points
    xs0, xs1 = 0, W
    ys0, ys1 = 0, H
    xw0, yw0 = ScreenToWorld(xs0, ys0)
    xw1, yw1 = ScreenToWorld(xs1, ys1)

    gxw0 = math.ceil(xw0)
    gxw1 = math.floor(xw1)
    gyw0 = math.floor(yw0)
    gyw1 = math.ceil(yw1)
    gxs0, gys0 = WorldToScreen(gxw0, gyw0)
    gxs1, gys1 = WorldToScreen(gxw1, gyw1)
    xsYAxis, ysXAxis = WorldToScreen(0, 0)
    
    # draw grid
    xw, xs = gxw0, gxs0
    while xs <= gxs1:
        pg.draw.line(canvas, pg.Color("black"), (xs, ys0), (xs, ys1))
        DrawText(str(int(xw)), xs, ys1-fontSize, pg.Color("black"))
        xw += 1
        xs += ScalingX
    yw, ys = gyw0, gys0
    while ys <= gys1:
        pg.draw.line(canvas, pg.Color("black"), (xs0, ys), (xs1, ys))
        DrawText(str(int(yw)), xs0, ys, pg.Color("black"))
        yw -= 1
        ys += ScalingY

    pg.draw.line(canvas, pg.Color("black"), (xs0, ysXAxis), (xs1, ysXAxis), 3) # x-axis
    pg.draw.line(canvas, pg.Color("black"), (xsYAxis, ys0), (xsYAxis, ys1), 3) # y-axis

    if message != '':
        DrawText(message, ex, ey, pg.Color("blue"))

    pg.display.update()

Draw()
while True:
    event = pg.event.wait()

    should_draw = False
    message = ''
    if event.type == pg.QUIT:
        break
    elif event.type == pg.MOUSEBUTTONDOWN:
        GridDragX0 = ex
        GridDragY0 = ey
        IsDraggingGrid = True
        should_draw = True
        pass
    elif event.type == pg.MOUSEMOTION:
        ex, ey = event.pos
        x, y = ScreenToWorld(ex, ey)
        message = '({:0.2f}, {:0.2f})'.format(x, y)
        should_draw = True
        if IsDraggingGrid:
            ex, ey = event.pos
            TranslationX += ex - GridDragX0
            TranslationY += ey - GridDragY0
            GridDragX0 = ex
            GridDragY0 = ey
    elif event.type == pg.MOUSEBUTTONUP:
        IsDraggingGrid = False
    elif event.type == pg.KEYDOWN:
        if event.key == pg.K_LEFT:
            TranslationX -= 5
            should_draw = True
        elif event.key == pg.K_RIGHT:
            TranslationX += 5
            should_draw = True
        elif event.key == pg.K_UP:
            TranslationY -= 5
            should_draw = True
        elif event.key == pg.K_DOWN:
            TranslationY += 5
            should_draw = True

    if event.type == pg.MOUSEBUTTONDOWN:
        if event.button == 4: # mousewheel up
            ScalingX /= 1.1
            ScalingY /= 1.1
            fontSize /= 1.1
            should_draw = True 
        elif event.button == 5: # mousewheel down
            ScalingX *= 1.1
            ScalingY *= 1.1
            fontSize *= 1.1
            should_draw = True

    if should_draw:
        Draw()

pg.quit()
