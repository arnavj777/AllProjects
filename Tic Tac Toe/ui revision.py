import pygame
import numpy
import time

# start pygame
pygame.init()
clock = pygame.time.Clock()
# screen
screen = pygame.display.set_mode((1000, 600))

# Title and Logo
pygame.display.set_caption('Tic Tac Toe')
logo = pygame.image.load('Tic-Tac-toe.png')
pygame.display.set_icon(logo)

# board
board = numpy.zeros((3, 3))

# Cross -- Player 1
crossimage = pygame.image.load('cross-sign.png')
crossX = 100
crossY = 180

# Circle -- Player 2
circleimage = pygame.image.load('circle.png')
circleX = 100
circleY = 360

# Spawns a cross


def cross(x, y):
    screen.blit(crossimage, (x, y))

# Spawns a Circle


def circle(x, y):
    screen.blit(circleimage, (x, y))

# Spawns Grid


line_color = (55, 115, 145)
line_width = 22

col = (0, 255, 255)


def grid():
    pygame.draw.line(screen, line_color, (200, 200), (800, 200), line_width)
    pygame.draw.line(screen, line_color, (200, 400), (800, 400), line_width)
    pygame.draw.line(screen, line_color, (400, 0), (400, 600), line_width)
    pygame.draw.line(screen, line_color, (600, 0), (600, 600), line_width)

    first_box = pygame.draw.rect(screen, col, pygame.Rect(200, 5, 190, 190))
    second_box = pygame.draw.rect(screen, col, pygame.Rect(400, 5, 190, 190))
    third_box = pygame.draw.rect(screen, col, pygame.Rect(600, 5, 190, 190))
    fourth_box = pygame.draw.rect(screen, col, pygame.Rect(200, 205, 190, 190))
    fifth_box = pygame.draw.rect(screen, col, pygame.Rect(400, 205, 190, 190))
    sixth_box = pygame.draw.rect(screen, col, pygame.Rect(600, 205, 190, 190))
    seventh_box = pygame.draw.rect(screen, col, pygame.Rect(200, 405, 190, 190))
    eighth_box = pygame.draw.rect(screen, col, pygame.Rect(400, 405, 190, 190))
    ninth_box = pygame.draw.rect(screen, col, pygame.Rect(600, 405, 190, 190))


col = (0, 255, 255)
first_box = pygame.draw.rect(screen, col, pygame.Rect(200, 5, 190, 190))
second_box = pygame.draw.rect(screen, col, pygame.Rect(400, 5, 190, 190))
third_box = pygame.draw.rect(screen, col, pygame.Rect(600, 5, 190, 190))
fourth_box = pygame.draw.rect(screen, col, pygame.Rect(200, 205, 190, 190))
fifth_box = pygame.draw.rect(screen, col, pygame.Rect(400, 205, 190, 190))
sixth_box = pygame.draw.rect(screen, col, pygame.Rect(600, 205, 190, 190))
seventh_box = pygame.draw.rect(screen, col, pygame.Rect(200, 405, 190, 190))
eighth_box = pygame.draw.rect(screen, col, pygame.Rect(400, 405, 190, 190))
ninth_box = pygame.draw.rect(screen, col, pygame.Rect(600, 405, 190, 190))


# Runs the game
screen.fill((100, 210, 20))

cross(crossX, crossY)
circle(circleX, circleY)
grid()

time.sleep(5)
'''
running = True
while running:
    screen.fill((100, 210, 20))
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
    cross(crossX, crossY)
    circle(circleX, circleY)
    grid()
    clock.tick(60)
    pygame.event.get()
    if event.type == pygame.MOUSEBUTTONUP:
        Pos = pygame.mouse.get_pos()
        if first_box.collidepoint(Pos):
            circle(270, 75)
        if second_box.collidepoint(Pos):
            circle(470, 75)

    else:
        pygame.display.update()

    pygame.display.update()
'''