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
*TO-DO ID CARD validation, phone number validation

Check Up:
*When the user wants to make an appointment with his doctor he has to select time and day.
*When a time is selected on todays date that time option will disappear for other patients who have the same doctor as the one who
just made the appointment.
*Other users who have the other doctor can see the previous booked time options from patients with the first doctor.
*When a patient wants to book a time example 09:00am and is 09:30 or more the program will say to choose another time since
this time has already passed.
*When a patient makes a booking with a previous day the program will say to choose todays date or a day of the future.
*If a patient wants to make todays day book at specific time and is already taken, they can click a day from the future and
again all the time options will appear to be selected. But before they are booked a check is made real quick if that time for that choosen day
is already booked by another patient with the same doctor as theirs. If it is booked the program will suggest to book another time or day.
*Every  time the shift starts or ends the previous apointments and bookings are made as "DONE" and the time schedule will appear again.
