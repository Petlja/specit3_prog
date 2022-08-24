import graph
import pygame as pg

COLOR, PT, LABEL_DIR, NGBRS = 0, 1, 2, 3
img_name_prefix = '4_grafovski/dfs'

def dfs():
    color = [graph.WHITE] * len(graph.vertices)
    for u in range(len(graph.vertices)):
        if graph.vertices[u][COLOR] == graph.WHITE:
            dfs_visit(u)
            
def dfs_visit(u):
    graph.vertices[u][COLOR] = graph.GRAY
    graph.draw_graph(img_name_prefix)
    for v in graph.vertices[u][NGBRS]:
        if graph.vertices[v][COLOR] == graph.WHITE:
            dfs_visit(v)
    graph.vertices[u][COLOR] = graph.BLACK
    graph.draw_graph(img_name_prefix)

def create_images(version):
    graph.set_graph(version)
    graph.draw_graph(img_name_prefix)
    dfs()

create_images(1)
create_images(2)

# while pg.event.wait().type != pg.QUIT:
    # pass
pg.quit()

