import pygame

# start pygame
pygame.init()
# screen
screen = pygame.display.set_mode((1000, 600))

# Title and Logo
pygame.display.set_caption('Tic Tac Toe')
logo = pygame.image.load('Tic-Tac-toe.png')
pygame.display.set_icon(logo)

# Cross -- Player 1
crossimage = pygame.image.load('cross-sign.png')
crossX = 100
crossY = 180

# Circle -- Player 2
circleimage = pygame.image.load('circle.png')
circleX = 100
circleY = 360

# Spawns a cross


def cross():
    screen.blit(crossimage, (crossX, crossY))

# Spawns a Circle


def circle():
    screen.blit(circleimage, (circleX, circleY))

# Spawns Grid


line_color = (55, 115, 145)
line_width = 22


def grid():
    pygame.draw.line(screen, line_color, (200, 200), (800, 200), line_width)
    pygame.draw.line(screen, line_color, (200, 400), (800, 400), line_width)
    pygame.draw.line(screen, line_color, (400, 0), (400, 600), line_width)
    pygame.draw.line(screen, line_color, (600, 0), (600, 600), line_width)


# Runs the game
running = True
while running:
    screen.fill((100, 210, 20))
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
    cross()
    circle()
    grid()
    pygame.display.update()

