# Task Description

create a small application which manages taxes applied in different municipalities.
The taxes are scheduled in time. Application should provide the user an ability to get taxes applied in
certain municipality at the given day.
Example: Municipality Vilnius has its taxes scheduled like this :
- yearly tax = 0.2 (for period 2016.01.01-2016.12.31),
- monthly tax = 0.4 (for period 2016.05.01-2016.05.31),
- it has no weekly taxes scheduled,
- and it has two daily taxes scheduled = 0.1 (at days 2016.01.01 and 2016.12.25).
The result according to provided example would be:

|Municipality (Input)  Date (Input) Result
|Vilnius               2016.01.01   0.1
|Vilnius               2016.05.02   0.4
|Vilnius               2016.07.10   0.2
|Vilnius               2016.03.16   0.2


# Requirements

Full requirements for the application (choose the priority of tasks in the way that when the time ends
up you would have working application, not necessarily with all functionality):

- [x] It has its own database where municipality taxes are stored
- [x] Taxes should have ability to be scheduled (yearly, monthly ,weekly ,daily) for each municipality
- [ ] Application should have ability to import municipalities data from file (choose one data format you believe is suitable)
- [x] Application should have ability to insert new records for municipality taxes (one record at a time) 
- [x] User can ask for a specific municipality tax by entering municipality name and date
- [x] Errors needs to be handled i.e. internal errors should not to be exposed to the end user
- [x] You should ensure that application works correctly

Bonus tasks (if there is time left)
- [x] Application is deployed as a self-hosted windows service
- [x] Update record functionality is exposed via API


#TODO:

- [x] Understand the task
- [x] Describe my data
- [x] Building blocks
 - [x] Function to calculate how many periods are hit on a certain date, return tax rate for the shortest period.
 - [x] Data access layer 
    - [x] 
    - [x] File IO (csv data import)
 - [x] Web endpoint

# Fails 

See Import Branch
- Connection string reading from config...
- Import application is console with its own connection string
- Webapi has its own way of wiring up connection string...
- Using local file as a database from nultiple locations creates path problems...

#Tools and Libraries used

- VS Code + Bash
- Entity Framework Core
- CsvHelper
- ASP.NET Core WebAPI
- Sqlite

# How to run

```
$nuget restore
$dotnet run -p webapi
```


# Thank you for the oportunity

MD


















