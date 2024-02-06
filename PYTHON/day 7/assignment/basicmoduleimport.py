#importing custom module

from basicmodule import *

#to tally up formatted dollars
tally_dollars = 0

valid_num = False
while valid_num == False:
    amount = input('Enter the price you would like to format (Type "N" to quit):\n')
    if amount.lower() == 'n':
        break #to get out of the loop
    try:
        amount = float(amount)
        format_to_dollars(amount) #changed (num) to (amount) and moved the call inside the loop
        tally_dollars += amount
    except Exception as ex:
        print('\nInput must be a number.\n\nException: %s\n' % (ex))

print('Tallied dollars: ${:.2f}'.format(tally_dollars))
