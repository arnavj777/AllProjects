import pygame
import numpy
import sys

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
blocka1 = pygame.image.load('blankblock.png')
blocka2 = pygame.image.load('blankblock.png')
blocka3 = pygame.image.load('blankblock.png')
blockb1 = pygame.image.load('blankblock.png')
blockb2 = pygame.image.load('blankblock.png')
blockb3 = pygame.image.load('blankblock.png')
blockc1 = pygame.image.load('blankblock.png')
blockc2 = pygame.image.load('blankblock.png')
blockc3 = pygame.image.load('blankblock.png')

# available blocks
blocka1_av = True
blocka2_av = True
blocka3_av = True
blockb1_av = True
blockb2_av = True
blockb3_av = True
blockc1_av = True
blockc2_av = True
blockc3_av = True



# Cross -- Player 1
crossimage = pygame.image.load('cross-sign.png')
crossX = 100
crossY = 180

# Circle -- Player 2
circleimage = pygame.image.load('circle.png')
circleX = 100
circleY = 360
player_turn = 'player_1'


# player turn function
def turn_changer():
    global player_turn
    if player_turn == 'player_1':
        player_turn = 'player_2'
    else:
        player_turn = 'player_1'



# Spawns a cross


def cross(x, y):
    screen.blit(crossimage, (x, y))

# Spawns a Circle


def circle(x, y):
    screen.blit(circleimage, (x, y))

# Spawns Grid


line_color = (55, 115, 145)
line_width = 22


def grid():
    pygame.draw.line(screen, line_color, (200, 200), (800, 200), line_width)
    pygame.draw.line(screen, line_color, (200, 400), (800, 400), line_width)
    pygame.draw.line(screen, line_color, (400, 0), (400, 600), line_width)
    pygame.draw.line(screen, line_color, (600, 0), (600, 600), line_width)
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
draw_circ_27075 = 0
while True:
    screen.fill((100, 210, 20))

    cross(crossX, crossY)
    circle(circleX, circleY)
    grid()
    clock.tick(60)
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            sys.exit()
        if event.type == pygame.MOUSEBUTTONDOWN:
            Pos = pygame.mouse.get_pos()
            if blocka1_av == True:
                if first_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blocka1 = pygame.image.load('cross-sign.png')
                        blocka1_av = False
                    else:
                        blocka1 = pygame.image.load('circle.png')
                    turn_changer()
                    blocka1_av = False
            if blocka2_av == True:
                if second_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blocka2 = pygame.image.load('cross-sign.png')
                    else:
                        blocka2 = pygame.image.load('circle.png')
                    turn_changer()
                    blocka2_av = False
            if blocka3_av == True:
                if third_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blocka3 = pygame.image.load('cross-sign.png')
                    else:
                        blocka3 = pygame.image.load('circle.png')
                    turn_changer()
                    blocka3_av = False
            if blockb1_av == True:
                if fourth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blockb1 = pygame.image.load('cross-sign.png')
                    else:
                        blockb1 = pygame.image.load('circle.png')
                    turn_changer()
                    blockb1_av = False
            if blockb2_av == True:
                if fifth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blockb2 = pygame.image.load('cross-sign.png')
                    else:
                        blockb2 = pygame.image.load('circle.png')
                    turn_changer()
                    blockb2_av = False
            if blockb3_av == True:
                if sixth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blockb3 = pygame.image.load('cross-sign.png')
                    else:
                        blockb3 = pygame.image.load('circle.png')
                    turn_changer()
                    blockb3_av = False
            if blockc1_av == True:
                if seventh_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blockc1 = pygame.image.load('cross-sign.png')
                    else:
                        blockc1 = pygame.image.load('circle.png')
                    turn_changer()
                    blockc1_av = False
            if blockc2_av == True:
                if eighth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blockc2 = pygame.image.load('cross-sign.png')
                    else:
                        blockc2 = pygame.image.load('circle.png')
                    turn_changer()
                    blockc2_av = False
            if blockc3_av == True:
                if ninth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        blockc3 = pygame.image.load('cross-sign.png')
                    else:
                        blockc3 = pygame.image.load('circle.png')
                    turn_changer()
                    blockc3_av = False



    screen.blit(blocka1, (270, 75))
    screen.blit(blocka2, (470, 75))
    screen.blit(blocka3, (670, 75))
    screen.blit(blockb1, (270, 275))
    screen.blit(blockb2, (470, 275))
    screen.blit(blockb3, (670, 275))
    screen.blit(blockc1, (270, 475))
    screen.blit(blockc2, (470, 475))
    screen.blit(blockc3, (670, 475))




    pygame.display.update()
