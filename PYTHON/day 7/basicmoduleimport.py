#importing custom module

from basicmodule import *
valid_num = False
while valid_num == False:
    amount = input('Enter the price you would like to format:\n')
    try:
        amount = float(num)
        valid_num = True
    except Exception as ex:
        print('\nInput must be a number.\n\nException: %s\n' % (ex))

format_to_dollars(amount)
