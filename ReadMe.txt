# AGL Coding Excercise a coding challenge task 

INSTRUCTIONS

 - How to Run

1. Download AGL.Pets solution


2. Download the Nuget packages - Following are the nuget packages used
	 package id="Castle.Core" version="4.2.1"
         package id="Castle.Windsor" version="4.1.0"
         package id="Newtonsoft.Json" version="11.0.1" 

3. Build solution


4. Execute the AGL.Pets.Main Project - This is console applicaiton, Output will be shown on the console window 

5. Execute the AGL Unit Tests project

6. Execute the Web Project, navigate to the PetsTest.html page to run the JavaScript unit tests




SOLUTION DESCRIPTION

The solution consists of 4 projects.



1. AGL.Pets.Contracts contains interfaces used for dependency injection (Castle) and classes.
 

2. AGL.Pets.UnitTests contains tests for the PersonsRepository.GetPets... 


3. AGL.Pets.Main is a Windows Console app project. This project defines a PersonRepository class which is used to list Pets in the requested structure described by the coding challenge.


4. A web project to demonstrate a testable JavaScript version

The Utiltity project also defines a DataContext class that is used by the repository to retrieve data. This DataContext class is an 
implementation of an IDataContext class which is injected (using Property Injection and the Castle Window IoC framework).

The concrete implementations of IDataContext includes a version which does not download Json data from the API service called FakeDataContext. 
This is useful for debugging, so the WindowsInstaller defines this as the concrete class for IDataContext given a pre-compiler directive of DEBUG.


Running the solution:
- AGL.Pets.Main project as a startup project and Run in debug mode, out put generated will be from the persons.json file in Sample Data.
- AGL.Pets.Main project as a startup projectwhen Run in Release mode, out put generated will be data from the Web API (http://agl-developer-test.azurewebsites.net/people.json).



Three Unit Tests target the PersonReporitoy method GetCatsByOwnerGender. The tests cover three cases:



1. Valid data and successful execution


2. Border case valid data and successful execution


3. Invalid data with an expected exception


