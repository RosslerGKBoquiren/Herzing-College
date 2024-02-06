#import library to connect to database
import sqlite3
#connection function to create a new database file (if not already made)
#or connect to the file in the root directory
db = sqlite3.connect('test.db')
#row_factory allows data to be accessed as keys
db.row_factory = sqlite3.Row
#to interact with the database, use cursor
cur = db.cursor()
#send commands to the database 
cur.execute('SELECT *FROM users')
#fetch all information and store it in variable rows
rows = cur.fetchall()

for each_row in rows:
    print(each_row)

cur.close()
