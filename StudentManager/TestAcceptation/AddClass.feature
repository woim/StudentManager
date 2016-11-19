Feature: AddClass
	In order to store the class in the data base
	As a school administrator
	I want to be able to add class to data base
	
Background: 
	Given I have one calss "PHY001" in the data base
	

@mytag
Scenario: Add a class - green path  
	When I add the class "MAT002" in the data base
	Then the modified database should have classes "PHY001" and "MAT002"


Scenario Outline: Add a class with a bad name format - red path
	When I add a class <Class> with bad format name
	Then I should get on the screen the error message "Error class name format incorrect."

	Examples: 
		| Class  | 
		| MA     |
		| MAGH1  |
		| MAT002 | 


Scenario: Add a class that already exist - red path
	When I add the class "PHY002" in the data base
	Then I should get on the screen the error message "Error class already exist."