#ask to enter their name
name = input("Please enter your name: ")
print("Welcome " + name)
#ask user for their age
age = input("Please enter your age: ")
print("Hi " + name + ". Age: " + age + " years old.")

if int(age) > 18:
    print("Welcome " + name)
else:
    print("You cannot have access to this website.")
    print("Goodbye!")
