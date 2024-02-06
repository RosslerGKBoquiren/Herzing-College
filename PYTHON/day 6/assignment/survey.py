import sqlite3

#create database
db = sqlite3.connect('rosslerboquiren.db')
#send command to database
#added IF NOT EXISTS due to errors from running the program constantly and inputing the same data again and again. 
db.execute('CREATE TABLE IF NOT EXISTS survey (id INTEGER PRIMARY KEY, choice TEXT)')

#function for favorite color option
def favorite_color():
    print('Color options:')
    print('1 - Black')
    print('2 - White')
    print('3 - Red')
    print('4 - Blue')
    print('5 - Green')
    print('9 - Quit')
    
#function to choose favorite color
def color_choice(choice):
    db.execute('INSERT INTO survey (choice) VALUES(?)', (str(choice),)) #provide value as tuple
    db.commit()
    
#query the results after the program ends
def query():
    results = db.execute('SELECT choice, COUNT(*) as count FROM survey GROUP BY choice').fetchall()
    #include newline
    print('\nSurvey Results:')
    for row in results:
        print('{}: {}'.format(row[0], row[1]))
        
#reset survey before starting a new submission
#reset will avoid adding previous results over another
def reset_survey():
    db.execute('DELETE FROM survey')
    db.commit()

#loop
while True:
    #adjust user inputs to lowercase answers
    user_input = input('Do you want to submit your favorite color? Yes or No: ').lower()
    
    if user_input == 'no':
        break
    elif user_input == 'yes':
        favorite_color()
        user_color = input('Enter the number of your favorite color: ')
        
        colors = {'1': 'Black', '2': 'White', '3': 'Red', '4': 'Blue', '5': 'Green'}
        
        if user_color in colors:
            color_choice(user_color + ' - ' + colors[user_color])
        elif user_color == '9':
            break
        else:
            print('Please choose a correct number.')

#call the function to print the results
query()

#call reset_survey function  
reset_survey()
    
#close connection from database
db.close()
