#function

def print_function():
    print('Hello, World')
    
print_function()


#function with variable
#name = input('What is your name? ')
def say_hello(name):
    print('Hello, ' + str(name))

#say_hello()


def get_name_say_hello():
    name = input('What is your name? ')
    say_hello(name)

get_name_say_hello()
