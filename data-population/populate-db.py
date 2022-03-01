import pyodbc
import names
import random
from random import randrange
from datetime import timedelta
from datetime import datetime

def random_date(start, end):
    """
    This function will return a random datetime between two datetime
    objects.
    """
    delta = end - start
    int_delta = (delta.days * 24 * 60 * 60) + delta.seconds
    random_second = randrange(int_delta)
    return start + timedelta(seconds=random_second)

driver = "{ODBC Driver 17 for SQL Server}"
#enter your database address here 
server = "(localdb)\MSSQLLocalDB"
#enter your database name here 
database = "FrogBlogDB"
#enter your username, if you have one, here
username = ""
#enter your password, if you have one, here
password = ""

cxstring = ("DRIVER=" + driver
        + ";SERVER=" + server
        + ";DATABASE=" + database)

if len(username) != 0:
    cxstring = cxstring + ";UID=" + username
    
if len(password) != 0:
    cxstring = cxstring + ";PWD=" + password 

conn = pyodbc.connect(cxstring) 

        
d1 = datetime.strptime('1/1/2015 1:30 PM', '%m/%d/%Y %I:%M %p')
d2 = datetime.strptime('1/1/2021 4:50 AM', '%m/%d/%Y %I:%M %p')
f = open("robinson-crusoe", "r")
lines = f.read().replace('\'', '').split("\n\n")
cursor = conn.cursor()

user_insert_statement = \
    """set identity_insert dbo.Users on;
    if ((select top 1 1 from Users where id = 0) is null)
    insert into users(Id, UserName, Salt, PasswordHash, Email)
    values
    (0, 'Blog-Admin', 'xyz', 'zyx', 'admin@blog.com')
    set identity_insert dbo.users off
    """

cursor.execute(user_insert_statement)
for line in lines:
    author = names.get_full_name()
    title_index_start = int(len(line.split(" "))/2)
    title = line.split(" ")[title_index_start] + " " +  line.split(" ")[title_index_start+1]
    content = str(line)
    date_time = str(random_date(d1, d2))
    cursor.execute("Insert into BlogPosts (Title, Content, DateTime, UserId) Values('%s', '%s', '%s', '%i' )"%(title, content, date_time, 1))
conn.commit()
cursor.close()
