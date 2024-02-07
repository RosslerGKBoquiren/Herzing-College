from tkinter import *

#Function entry_one_button click
def click_input_one():
    print('Entry 1: ' + input_one)

#Function entry_one_button click
def click_input_two():
    print('Entry 1: ' + input_two)


#window with title and dimension
root = Tk()
root.title('Python GUI Application')
root.geometry('500x250')

#entry 1
input_one_label = Label(root, text = 'Entry ONE')
input_one_label.pack(side = 'left', padx = 10, pady = 10)
#Store value entry_one
input_one = StringVar()
input_one_entry = Entry(root, textvariable = input_one)
input_one_entry.pack(padx = 10, pady = 10)
#button for entry 1
input_one_button = Button(root, text = 'Show Entry 1', command = click_input_one)
input_one_button.pack(side = 'right', padx = 10, pady = 10)

#entry 2
input_two_label = Label(root, text = 'Entry TWO')
input_two_label.pack(side = 'left',padx = 10, pady = 10)
#store value entry_two
input_two = StringVar()
input_two_entry = Entry(root, textvariable = input_two)
input_two_entry.pack(padx = 10, pady = 10)
#button for entry 2
input_two_button = Button(root, text = 'Show Entry 2', command = click_input_two)
input_two_button.pack(side = 'right',padx = 10, pady = 10)

root.mainloop()
