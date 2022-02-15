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
server = "localhost,1433"
database = "FrogBlog"
username = "sa"
password = "34r0TNhvgOde"
conn = pyodbc.connect("DRIVER=" + driver
        + ";SERVER=" + server
        + ";DATABASE=" + database
        + ";UID=" + username
        + ";PWD=" + password )

d1 = datetime.strptime('1/1/2015 1:30 PM', '%m/%d/%Y %I:%M %p')
d2 = datetime.strptime('1/1/2021 4:50 AM', '%m/%d/%Y %I:%M %p')
f = open("robinson-crusoe", "r")
lines = f.read().replace('\'', '').split("\n")
cursor = conn.cursor()

for line in lines:
    author = names.get_full_name()
    title = line.split(" ")[int(len(line.split(" "))/2)]
    content = str(line)
    date_time = str(random_date(d1, d2))
    cursor.execute("Insert into BlogPosts (Title, Content, DateTime, PostedBy) Values('%s', '%s', '%s', '%s' )"%(title, content, date_time, author))
conn.commit()
cursor.close()
