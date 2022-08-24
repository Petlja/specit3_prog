import math
import pygame as pg

X, Y = 0, 1

pg.init()

pg.display.set_caption("Обим и површина многоугла")
(W, H) = (800, 600)
canvas = pg.display.set_mode((W, H))

ScalingX = 50.0
ScalingY = 50.0
TranslationX = 20.0
TranslationY = 580.0
GridDragX0 = -1
GridDragY0 = -1
IsDraggingGrid = False
ex, ey = 0, 0 # mouse position
message = ''
PtsW  = [] # vertices in world coordinates

def WorldToScreen(xw, yw):
    xs = xw * ScalingX + TranslationX
    ys = -yw * ScalingY + TranslationY
    return (xs, ys)

def ScreenToWorld(xs, ys):
    xw = (xs - TranslationX) / ScalingX
    yw = (ys - TranslationY) / -ScalingY
    return (xw, yw)

def DrawText(s, x, y):
    font = pg.font.SysFont("Arial", 25)
    txt = font.render(s, True, pg.Color("red"))
    tw, th = (txt.get_width(), txt.get_height())
    x, y = (x - tw * (x / W), y - th * (y / H))
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
    xs = gxs0
    while xs <= gxs1:
        pg.draw.line(canvas, pg.Color("black"), (xs, ys0), (xs, ys1))
        xs += ScalingX
    ys = gys0
    while ys <= gys1:
        pg.draw.line(canvas, pg.Color("black"), (xs0, ys), (xs1, ys))
        ys += ScalingY

    pg.draw.line(canvas, pg.Color("black"), (xs0, ysXAxis), (xs1, ysXAxis), 3) # x-axis
    pg.draw.line(canvas, pg.Color("black"), (xsYAxis, ys0), (xsYAxis, ys1), 3) # y-axis

    n = len(PtsW)
    ptsS = [] # list of vertices in screen coordinates
    for i in range(n):
        x, y = WorldToScreen(PtsW[i][X], PtsW[i][Y])
        ptsS.append((x, y))

    # draw vertices using screen coordinates
    if n > 0:
        pg.draw.line(canvas, pg.Color("blue"), ptsS[n - 1], ptsS[0], 3)
        for i in range(1, n):
            pg.draw.line(canvas, pg.Color("blue"), ptsS[i - 1], ptsS[i], 3)
            
    if message != '':
        DrawText(message, ex, ey)

    pg.display.update()


def Distance(A, B):
    dx = B[0] - A[0]
    dy = B[1] - A[1]
    return math.sqrt(dx * dx + dy * dy)

def ComputeAreaAndPerimeter():
    n = len(PtsW)
    if n < 3:
        return
    
    perimeter = Distance(PtsW[n - 1], PtsW[0])
    for i in range(1, n):
        perimeter += Distance(PtsW[i - 1], PtsW[i])

    area = PtsW[0][X] * (PtsW[n - 1][Y] - PtsW[1][Y])
    area += PtsW[n - 1][X] * (PtsW[n - 2][Y] - PtsW[0][Y])
    for i in range(1, n-1):
        area += PtsW[i][X] * (PtsW[i - 1][Y] - PtsW[i + 1][Y])

    area = 0.5 * abs(area)

    # pg.display.set_caption(f'Обим={perimeter:0.2f}, Површина={area:0.2f}')
    pg.display.set_caption('Обим={:0.2f}, Површина={:0.2f}'.format(perimeter, area))


Draw()
while True:
    dogadjaj = pg.event.wait()

    should_draw = False
    message = ''
    if dogadjaj.type == pg.QUIT:
        break
    elif dogadjaj.type == pg.MOUSEBUTTONDOWN:
        # add new vertex (transformed to world coordinates)
        ex, ey = dogadjaj.pos
        x, y = ScreenToWorld(ex, ey)
        PtsW.append((x, y))
        ComputeAreaAndPerimeter()
        should_draw = True
        # if right mouse button:
            # IsDraggingGrid = True
            # GridDragX0 = ex
            # GridDragY0 = ey
    elif dogadjaj.type == pg.MOUSEMOTION:
        ex, ey = dogadjaj.pos
        x, y = ScreenToWorld(ex, ey)
        message = '({:0.2f}, {:0.2f})'.format(x, y)
        should_draw = True
        # if IsDraggingGrid:
            # ex, ey = dogadjaj.pos
            # TranslationX += ex - GridDragX0
            # TranslationY += ey - GridDragY0
            # GridDragX0 = ex
            # GridDragY0 = ey
            # should_draw = True
    elif dogadjaj.type == pg.MOUSEBUTTONUP:
        pass
        # if right mouse button:
            # IsDraggingGrid = False
    elif dogadjaj.type == pg.KEYDOWN:
        if dogadjaj.key == pg.K_LEFT:
            TranslationX -= 5
            should_draw = True
        elif dogadjaj.key == pg.K_RIGHT:
            TranslationX += 5
            should_draw = True
        elif dogadjaj.key == pg.K_UP:
            TranslationY -= 5
            should_draw = True
        elif dogadjaj.key == pg.K_DOWN:
            TranslationY += 5
            should_draw = True
    if should_draw:
        Draw()

pg.quit()
