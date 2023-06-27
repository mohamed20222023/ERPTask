
Hello and welcome to this Employee Data Application!

This application is designed for managing employee data and storing it in an SQL database. It is built on .NET Core MVC, with MSSQL as the database engine and EF as the ORM.

To use this application, you will need to input the following required fields for each employee:

Name (text only)
ID (number only)
National ID (14 numbers)
Date of Birth (not less than 18 years)
Age (automatic from Date of Birth, client-side)
Account (list of values)
Line of Business (list of values, dependent on Account)
Language (list of 5 languages)
Language level (multiple selections to select more than 1 level)
The application is built to ensure that only "Admin" users can access the view page for adding, editing, and deleting employee data. User privileges are managed through Identity.

In addition, the application offers an "Export to Excel" option and a "Dashboard View" that provides data visualization for the saved records in two charts: pie and line chart.

To use this application, simply clone the repository and open the solution in Visual Studio. You will need to run the application locally on your machine using IIS Express or another web server.

Thank you for using this Employee Data Application!
