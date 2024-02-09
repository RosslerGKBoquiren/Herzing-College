from tkinter import *

#Function entry_one_button click
def click_input_one():
    print('Entry 1: ' + input_one.get()) #.get to retrieve values from 'StringVar'

#Function entry_one_button click
def click_input_two():
    print('Entry 2: ' + input_two.get())


#window with title and dimension
root = Tk()
root.title('Python GUI Application')
root.geometry('500x250')

#entry 1
input_one_label = Label(root, text = 'Entry ONE')
#using grid to arrange in rows* and columns*
input_one_label.grid(row = 0, column = 1, padx = 10, pady = 10) 
#Store value entry_one
input_one = StringVar()
input_one_entry = Entry(root, textvariable = input_one)
input_one_entry.grid(row = 0, column = 2, padx = 10, pady = 10)
#button for entry 1
input_one_button = Button(root, text = 'Show Entry 1', command = click_input_one)
input_one_button.grid(row = 0, column = 3, padx = 10, pady = 10)

#entry 2
input_two_label = Label(root, text = 'Entry TWO')
input_two_label.grid(row = 1, column = 1, padx = 10, pady = 10)
#store value entry_two
input_two = StringVar()
input_two_entry = Entry(root, textvariable = input_two)
input_two_entry.grid(row = 1, column = 2, padx = 10, pady = 10)
#button for entry 2
input_two_button = Button(root, text = 'Show Entry 2', command = click_input_two)
input_two_button.grid(row = 1, column = 3, padx = 10, pady = 10)

root.mainloop()
