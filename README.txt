In this file you will read the validation and filter that the web application has.

Register:

*When a user register they must put full name, email, username, password and select one from the two doctors.
*When the button submit is clicked a validation is made where it checks if this username and email that are entered exist
or not in the databse. If they exist the user will be given option to change the values or login if they already have an account.
*Password must be more then 8 characters long

Login:

*A user must always login to access the site, there is session security that wont allow people to navigate through the site from 
changing url.
*Login requires username and password to be successfull.

Users Profile:

*The user can add extra information about themselves like ID Card number, Phone number, Address, City, State, Zip Code etc..
*Validation for ID card and password, ID card format is A12345678B meaning two capital letters front and end and in between 8 digit numbers
and password is required to be 8 characters long and with one capital letter miminum.

Check Up and the other similar pages:

*When the user wants to make an appointment with his doctor he has to select time and day.
*When a time is selected on todays date that time option will disappear for other patients who have the same doctor as the one who
just made the appointment.
*Other users who have the other doctor can see the previous booked time options from patients with the first doctor.
*When a patient wants to book a time example 09:00am and is 09:30 or more the program will say to choose another time since
this time has already passed.
*When a patient makes a booking with a previous day the program will say to choose todays date or a day of the future.
*If a patient wants to make todays day book at specific time and is already taken, they can click a day from the future and
the calendar will update first will check if any appointments are made for that date and if yes those specific time options will disppear showing
only the available ones to the client. This date-time checking is matched according to the patients doctor.

Total Appointments:

*It has a dynamic search bar that concats all the values like ID, Service name, Comment,Time,Date
*It has a drop down list with options like: All Appointments,Future Appointments,Todays Appointments,Past Appointments and Date Interval
*For date interval you are given two calendars to select first and second date and the query will fetch results from start date to end date.
*Download and export values in excel file.

Free Time:

*In this panel user can see when their doctor is free, the default date is todays date
*It has a calendar that shows free time for specific date for their specific doctor that the patient has choosen
*Download and export values to excel

Register with facebook:

*At the register panel you are given option to continue with facebook
*When you click the button a window is open that will tell you to login your facebook credentials
if those credentials are correct from the API of facebook the web receives:
*Full Name, Email, First Name,Access_Token
*Since password will not be given for security reasons the security token is used as password and account is created

Login with facebook:

*When you want to login you are given the option to login with facebook
*When you click the button if you are already login at your facebook the values are taken automatically or you have to login again
*For username is taken your First Name and for password is the Access_Token.
*Since the Access_Token changes everytime a new API call is made i thought for the login part to make it like this:
One copy of the access_token i print it on the password textbox and the other copy i insert it on cookies
when you click login the program will compare the password text value with the cookies value if they both are the same
the user is given access to the program

***FOR FACEBOOK TO WORK THE PROGRAM MUST BE ON HTTPS://
For this i made the solution to make the programs root file Enable SSL Certificate

