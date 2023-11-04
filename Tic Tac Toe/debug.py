

Rows = [['o','o','x'],
        ['o','o','x'],
        ['x','x','x']]

column = 0
for i in range(0, 3):
    if Rows[0][column] == Rows[1][column] and Rows[2][column] == Rows[0][column]:
        if Rows[0][column] == 'x':
            print('x win')
        elif Rows[0][column] == 'o':
            print('o win')
    column += 1