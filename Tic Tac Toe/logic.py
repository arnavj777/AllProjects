def check(type):
    global player1_win
    global player2_win
    if type == 'top-bottom':
        column = 0
        for i in range(0,3):
            if Rows[0][column] == Rows[1][column] and Rows[2][column] == Rows[0][column]:
                if Rows[0][column] == 'player1':
                    player1_win = True
                elif Rows[0][column] == 'player2':
                    player2_win = True
            column += 1
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
