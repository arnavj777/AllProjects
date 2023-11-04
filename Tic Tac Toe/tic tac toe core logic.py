import pygame
import sys
import time


Rows = [['empty', 'empty', 'empty'],
        ['empty', 'empty', 'empty'],
        ['empty', 'empty', 'empty']]

player1_win = False
player2_win = False
end = False


def draw():
    if squarea1_av == False and squarea2_av == False and squarea3_av == False and\
    squareb1_av == False and squareb2_av == False and squareb3_av == False and squarec1_av == False\
    and squarec2_av == False and squarec3_av == False and player1_win == False and player2_win == False:
        draw = pygame.image.load('draw.png')
        screen.blit(draw, (100, 50))
        global end
        end = True






def check(type):
    global player1_win
    global player2_win
    if type == 'top-bottom':
        column = 0
        new_check = False
        for i in range(0, 3):
            if new_check == False:
                if Rows[0][column] == Rows[1][column] and Rows[2][column] == Rows[0][column]:
                    if Rows[0][column] == 'player1':
                        player1_win = True
                    elif Rows[0][column] == 'player2':
                        player2_win = True
                column += 1
                new_check = True
            elif new_check == True:
                if Rows[1][0] == Rows[1][1] and Rows[1][0] == Rows[1][2]:
                    if Rows[1][0] == 'player1':
                        player1_win = True
                    elif Rows[1][0] == 'player2':
                        player2_win = True
                if Rows[2][0] == Rows[2][1] and Rows[2][0] == Rows[2][2]:
                    if Rows[2][0] == 'player1':
                        player1_win = True
                    elif Rows[2][0] == 'player2':
                        player2_win = True
    elif type == 'side-side':
        row = 0
        if Rows[row][0] == Rows[row][1] and Rows[row][2] == Rows[row][0]:
            if Rows[row][0] == 'player1':
                player1_win = True
            elif Rows[row][0] == 'player2':
                player2_win = True
        row += 1
    elif type == 'diagonal':
        row1 = 0
        column1 = 0
        row2 = 2
        column2 = 2
        for i in range(0, 2):
            if Rows[1][1] == Rows[row1][column1] and Rows[row2][column2] == Rows[1][1]:
                if Rows[row1][column1] == 'player1':
                    player1_win = True
                if Rows[row1][column1] == 'player2':
                    player2_win = True
            row1 += 2
            row2 -= 2


def big_check():
    check('top-bottom')
    check('side-side')
    check('diagonal')


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
squarea1 = pygame.image.load('blankblock.png')
squarea2 = pygame.image.load('blankblock.png')
squarea3 = pygame.image.load('blankblock.png')
squareb1 = pygame.image.load('blankblock.png')
squareb2 = pygame.image.load('blankblock.png')
squareb3 = pygame.image.load('blankblock.png')
squarec1 = pygame.image.load('blankblock.png')
squarec2 = pygame.image.load('blankblock.png')
squarec3 = pygame.image.load('blankblock.png')

# available squares
squarea1_av = True
squarea2_av = True
squarea3_av = True
squareb1_av = True
squareb2_av = True
squareb3_av = True
squarec1_av = True
squarec2_av = True
squarec3_av = True



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
def turn_maker():
    global player_turn
    if player_turn == 'player_1':
        player_turn = 'player_2'
    else:
        player_turn = 'player_1'




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


player1_victory = pygame.image.load('x wins.png')
player2_victory = pygame.image.load('o wins.png')

# Runs the game
draw_circ_27075 = 0

while True:
    screen.fill((100, 210, 20))

    if end == True:
        time.sleep(5)
        pygame.quit()
        sys.exit()
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
            if squarea1_av == True:
                if first_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squarea1 = pygame.image.load('cross-sign.png')
                        Rows[0][0] = 'player1'
                    else:
                        squarea1 = pygame.image.load('circle.png')
                        Rows[0][0] = 'player2'
                    turn_maker()
                    squarea1_av = False
            if squarea2_av == True:
                if second_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squarea2 = pygame.image.load('cross-sign.png')
                        Rows[1][0] = 'player1'
                    else:
                        squarea2 = pygame.image.load('circle.png')
                        Rows[1][0] = 'player2'
                    turn_maker()
                    squarea2_av = False
            if squarea3_av == True:
                if third_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squarea3 = pygame.image.load('cross-sign.png')
                        Rows[2][0] = 'player1'
                    else:
                        squarea3 = pygame.image.load('circle.png')
                        Rows[2][0] = 'player2'
                    turn_maker()
                    squarea3_av = False
            if squareb1_av == True:
                if fourth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squareb1 = pygame.image.load('cross-sign.png')
                        Rows[0][1] = 'player1'
                    else:
                        squareb1 = pygame.image.load('circle.png')
                        Rows[0][1] = 'player2'
                    turn_maker()
                    squareb1_av = False
            if squareb2_av == True:
                if fifth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squareb2 = pygame.image.load('cross-sign.png')
                        Rows[1][1] = 'player1'
                    else:
                        squareb2 = pygame.image.load('circle.png')
                        Rows[1][1] = 'player2'
                    turn_maker()
                    squareb2_av = False
            if squareb3_av == True:
                if sixth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squareb3 = pygame.image.load('cross-sign.png')
                        Rows[2][1] = 'player1'
                    else:
                        squareb3 = pygame.image.load('circle.png')
                        Rows[2][1] = 'player2'
                    turn_maker()
                    squareb3_av = False
            if squarec1_av == True:
                if seventh_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squarec1 = pygame.image.load('cross-sign.png')
                        Rows[0][2] = 'player1'
                    else:
                        squarec1 = pygame.image.load('circle.png')
                        Rows[0][2] = 'player2'
                    turn_maker()
                    squarec1_av = False
            if squarec2_av == True:
                if eighth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squarec2 = pygame.image.load('cross-sign.png')
                        Rows[1][2] = 'player1'
                    else:
                        squarec2 = pygame.image.load('circle.png')
                        Rows[1][2] = 'player2'
                    turn_maker()
                    squarec2_av = False
            if squarec3_av == True:
                if ninth_box.collidepoint(Pos):
                    if player_turn == 'player_1':
                        squarec3 = pygame.image.load('cross-sign.png')
                        Rows[2][2] = 'player1'
                    else:
                        squarec3 = pygame.image.load('circle.png')
                        Rows[2][2] = 'player2'
                    turn_maker()
                    squarec3_av = False



    screen.blit(squarea1, (270, 75))
    screen.blit(squarea2, (470, 75))
    screen.blit(squarea3, (670, 75))
    screen.blit(squareb1, (270, 275))
    screen.blit(squareb2, (470, 275))
    screen.blit(squareb3, (670, 275))
    screen.blit(squarec1, (270, 475))
    screen.blit(squarec2, (470, 475))
    screen.blit(squarec3, (670, 475))
    print(Rows)
    big_check()
    draw()
    if player1_win:
        screen.blit(player1_victory, (200,200))
        end = True

    if player2_win:
        screen.blit(player2_victory, (200,200))
        end = True


    clock.tick(60)




    pygame.display.update()









































