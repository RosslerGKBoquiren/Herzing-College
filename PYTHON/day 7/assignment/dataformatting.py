#data formatting

name = 'Samuel Chabot'
user_input = input('What is the price? ')

price = float(user_input) * 1.15 #adding tax

#using string concatenation
print(name + ', the price is: $' + str(price))

#<format_string> % <values>
print('%s, the price is: $%f' % (name, price))
#s = string
#f = float
