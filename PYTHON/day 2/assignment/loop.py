# Get sentence from user
sentence = input('Enter a sentence: ')

# Empty variable to store reversed sentence
reversed_sentence = ''

# Loop through each letter(i) in the sentence in reverse order
for characters in reversed(sentence):
    reversed_sentence += characters

# Print the original sentence and reversed sentences
print('Original sentence: ' + sentence)
print('Reversed sentence: ' + reversed_sentence)
