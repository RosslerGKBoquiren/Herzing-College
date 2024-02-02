#Part 1
def checkNameGuesses (guessesArray, secretName):
    for guess in guessesArray:
        if guess == secretName:
            return True
    return False

def reverseNamesAndWriteToFile(guessesArray, filename="reversed_names.txt"):
    with open(filename, 'w') as file:
       for name in reversed(guessesArray):
            file.write(name + '\n')

#Variable holding secretName
secretName = 'Evans'
guessesArray = []

#Let user guess secret name 5x times
#Save guesses in guessesArray
for number in range(5):
    guess = input('Enter guess #' + str(number + 1) + ': ')
    guessesArray.append(guess)

#Call function to check if guess == secretName
result = checkNameGuesses(guessesArray, secretName)

#Print result
if result:
    print('Congratulations! You guessed the secret name.')
else:
    print('Sorry, you did not guess the secret name.')


#Part 2
#Call function to reverse names and write to a file
reverseNamesAndWriteToFile(guessesArray)
print('Reversed name orders have been written to "reversed_names.txt".')
