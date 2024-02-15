#Function to get two numbers
def getNumbers():
    num1 = float(input('Enter the first number: '))
    num2 = float(input('Enter the second number: '))
    return [num1, num2]

#Validation function
def validateNumbers():
    while True:
        try:
            numbers = getNumbers()
            break
        except ValueError:
            print('Please enter valid numbers.')

    return numbers

#Display function for Number information
def displayNumbers(num1, num2):
    # First if/elif/else block
    if num1 > 0 and num2 > 0:
        print('2 positive numbers')
    elif num1 < 0 and num2 < 0:
        print('2 negative numbers')
    elif num1 > 0 and num2 < 0:
        print('num1 is positive, num2 is negative')
    elif num1 < 0 and num2 > 0:
        print('num1 is negative, num2 is positive')
    else:
        #Numbers have different signs or at least one is zero
        print('Numbers have different signs or at least one is zero')

    #Second if/elif/else block
    if num1 > 0 or num2 > 0:
        print('JUST One number is positive')
    elif num1 < 0 or num2 < 0:
        print('JUST One number is negative')
    else:
        print('Both numbers are zero')

    #Calculate and display the results of the arithmetic operations
    addition = num1 + num2
    subtraction = num1 - num2
    multiplication = num1 * num2
    try:
        division = num1 / num2
        print('Division: {}'.format(division))
    except ZeroDivisionError:
        #Handle division by zero error
        print('Error: Division by Zero')
        
    #Display results
    print('Addition: {}'.format(addition))
    print('Subtraction: {}'.format(subtraction))
    print('Multiplication: {}'.format(multiplication))

#Call the functions
if __name__ == '__main__':
    #Validate numbers
    numbers = validateNumbers()
    #Display information and execute arithmetic operations
    displayNumbers(*numbers)
