Feature: AddClass
	In order to store the class in the data base
	As a school administrator
	I want to be able to add class to data base
	
@mytag
Scenario Outline: Add a class - green path
	Given I have one "PHY001" in the data base  
	When I enter the command "-f testDB -addClass <Class2>"
	Then the modified database should be 

	Examples: 
		| Class1 | Class2 | 
		| PHY001 | MAT002 |


Scenario Outline: Add a class with a bad name format - red path
	Given I have one "PHY002" in the data base
	When I enter the command "-f testDB -addClass <Class>"
	Then I should get on the screen "Error class name format incorrect."

	Examples: 
		| Class  | 
		| MA     |
		| MAGH1  |
		| MAT002 | 

Scenario: Add a class that already exist - red path
	Given I have a "PHY002" in the data base 
	When I enter the command "-f testDB -addClass PHY002"
	Then I should get on the screen "Error class already exist."
