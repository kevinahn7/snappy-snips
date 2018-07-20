# Hair Salon

#### Epicodus C# Individual Project #4, July 20th, 2018

#### By Kevin Ahn

## Description

This program lets you manage a hair salon and helps you keep track of which stylists has which clients and to add more stylists or clients to the database. This is a continuation of the project hair-salon to add additional features.

## User Stories

* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.
* As an employee, I need to be able to delete stylists (all and single).
* As an employee, I need to be able to delete clients (all and single).
* As an employee, I need to be able to view clients (all and single).
* As an employee, I need to be able to edit JUST the name of a stylist. (You can choose to allow employees to edit additional properties but it is not required.)
* As an employee, I need to be able to edit ALL of the information for a client.
* As an employee, I need to be able to add a specialty and view all specialties that have been added.
* As an employee, I need to be able to add a specialty to a stylist.
* As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
* As an employee, I need to see the stylist's specialties on the stylist's details page.
* As an employee, I need to be able to add a stylist to a specialty.



## Setup on OSX

* Download and install .Net Core 2.0
* Download and install Mono
* Clone the repo
* Run `dotnet restore` from within the project directory
* Run `dotnet build` from project directory to build the project
* Run `dotnet test` from the test directory to test the tests
* Run `dotnet run` from the test directory to start the server

## Receate database
* CREATE DATABASE hair_salon
* USE hair_salon
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), details VARCHAR(255), clinet_id INT)
* CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255))

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 2.0
*  MySQL
*  MAMP


## Links

* [The Repository](https://github.com/kevinahn7/snappy-snips)

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Kevin Ahn**