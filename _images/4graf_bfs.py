import graph
import pygame as pg
from queue import Queue

COLOR, PT, LABEL_DIR, NGBRS = 0, 1, 2, 3
img_name_prefix = '4_grafovski/bfs'

def bfs():
    color = [graph.WHITE] * len(graph.vertices)
    for u in range(len(graph.vertices)):
        if graph.vertices[u][COLOR] == graph.WHITE:
            graph.vertices[u][COLOR] = graph.GRAY
            graph.draw_graph(img_name_prefix)
            bfs_visit(u, 0)
            
def bfs_visit(u, depth):
    q = Queue()
    q.put(u)
    while not q.empty():
        u = q.get()
        for v in graph.vertices[u][NGBRS]:
            if graph.vertices[v][COLOR] == graph.WHITE:
                q.put(v)
                graph.vertices[v][COLOR] = graph.GRAY
                graph.draw_graph(img_name_prefix)
        graph.vertices[u][COLOR] = graph.BLACK
        graph.draw_graph(img_name_prefix)

def create_images(version):
    graph.set_graph(version)
    graph.draw_graph(img_name_prefix)
    bfs()

create_images(1)
create_images(2)

# while pg.event.wait().type != pg.QUIT:
    # pass
pg.quit()

