# Get sentence from user
sentence = input('Enter a sentence: ')

# Empty variable to store reversed sentence
reversed_sentence = ''

# Loop through each letter(i) in the sentence in reverse order
for i in reversed(sentence):
    reversed_sentence += i

# Print the original sentence and reversed sentences
print('Original sentence: ' + sentence)
print('Reversed sentence: ' + reversed_sentence)
