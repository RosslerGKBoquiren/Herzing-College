name = input('What is your name? ')
age = input('How old are you? ')

print('Welcome,' + name)

if int(age) < 5:
    print('You are very young');
elif 5 <= int(age) < 15:
    print('You are young');
elif 15 <= int(age) < 30:
    print('You are a young adult');
elif 30 <= int(age) < 50:
    print('You are an adult');
elif 50 <= int(age) < 65:
    print('You are middle aged');
else:
    print('You are a senior citizen');
