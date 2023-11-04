x = 1
y = 2
z = 0
Row_1 = [x, y, y]
Row_2 = [y, x, x]
Row_3 = [y, y, x]
'''
# Checks values for 1st value in first row
if Row_1[0] == x:
    print('row 1 first value is x')
elif Row_1[0] == y:
    print('row 1 first value is y')
else:
    print('row 1 first value is none')

# Checks values for 2nd value in first row
if Row_1[1] == x:
    print('row 1 second value is x')
elif Row_1[1] == y:
    print('row 1 second value is y')
else:
    print('row 1 second value is none')

# Checks values for 3rd value in first row
if Row_1[2] == x:
    print('row 1 third value is x')
elif Row_1[2] == y:
    print('row 1 third value is y')
else:
    print('row 1 third value is none')
'''
# Checks first list if there are 3 equal values
if Row_1[0] == x and Row_1[1] == x and Row_1[2] == x:
    print('X wins')
    exit()
elif Row_1[0] == y and Row_1[1] == y and Row_1[2] == y:
    print('y wins')
    exit()
else:
    if Row_2[0] == x and Row_2[1] == x and Row_2[2] == x:
        print('X wins')
        exit()
    elif Row_2[0] == y and Row_2[1] == y and Row_2[2] == y:
        print('y wins')
        exit()
    else:
        if Row_3[0] == x and Row_3[1] == x and Row_3[2] == x:
            print('X wins')
            exit()
        elif Row_3[0] == y and Row_3[1] == y and Row_3[2] == y:
            print('y wins')
            exit()
        else:
         print('draw')
        
'''
# Checks second list if there are 3 equal values
if Row_2[0] == x and Row_2[1] == x and Row_2[2] == x:
    print('X wins')
    exit()
elif Row_2[0] == y and Row_2[1] == y and Row_2[2] == y:
    print('y wins')
    exit()
else:
    print('2nd row draw')

# Checks third list if there are 3 equal values
if Row_3[0] == x and Row_3[1] == x and Row_3[2] == x:
    print('X wins')
    exit()
elif Row_3[0] == y and Row_3[1] == y and Row_3[2] == y:
    print('y wins')
    exit()
else:
    print('draw')
    '''