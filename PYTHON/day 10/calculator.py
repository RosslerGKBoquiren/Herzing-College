from tkinter import*

#function for addition
def add():
    result.set(float(first_number.get()) + float(second_number.get()))
#function for subtraction
def subtract():
    result.set(float(first_number.get()) - float(second_number.get()))
#function for multiply
def multiply():
    result.set(float(first_number.get()) * float(second_number.get()))
#function for divide
def divide():
    try:
        result.set(float(first_number.get()) / float(second_number.get()))
    except ZeroDivisionError:
        result.set('Error: Cannot divide by Zero')

#Graphic User Interface Calculator
root = Tk() #main window object
root.title('Simple Calculator') #Title
root.geometry('500x200') #size of the window width x height

#entry fields
first_number = Entry(root)
first_number.pack(pady = 10)
second_number = Entry(root)
second_number.pack(pady = 10)

#display buttons
Button(root, text = 'Add', command = add).pack(side = 'left', padx = 10)
Button(root, text = 'Subtract', command = subtract).pack(side = 'left', padx = 10)
Button(root, text = 'Multiply', command = multiply).pack(side = 'right', padx = 10)
Button(root, text = 'Divide', command = divide).pack(side = 'right', padx = 10)

#display results
result = StringVar()
Label(root, textvariable = result).pack(pady = 10)

root.mainloop()
