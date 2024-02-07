#import tkinter library
from tkinter import *

def button1_click():
    print('You clicked Button ONE')

def button2_click():
    print('You clicked Button TWO')

#call tk function and assign to a variable
root = Tk()
#title of window
root.title('Application Title')
#size of window
root.geometry('600x200')

#definition of label
my_label = Label(root, text = 'Hello, World!')
#putting inside the root
my_label.pack(side = 'top')

#button widgets
#definition of button
btn1 = Button(root, text = 'Button ONE', width = 10, command = button1_click)
btn1.pack(side = 'left', pady = 10)

btn2 = Button(root, text = 'Button TWO', width = 10, command = button2_click)
btn2.pack(side = 'right', pady = 10)

#root always at the end of the code
root.mainloop()
