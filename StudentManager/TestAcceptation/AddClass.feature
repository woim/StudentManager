Feature: AddClass
	In order to store the class in the data base
	As a school administrator
	I want to be able to add class to data base
	
@mytag
Scenario: Add a class - green path
	Given I have one calss "PHY001" in the data base  
	When I add the class "MAT002" in the data base
	Then the modified database should have 2 classes "PHY001" "MAT002"


Scenario Outline: Add a class with a bad name format - red path
	Given I have one calss "PHY001" in the data base  
	When I add a class <Class> with bad format name
	Then I should get on the screen "Error class name format incorrect."

	Examples: 
		| Class  | 
		| MA     |
		| MAGH1  |
		| MAT002 | 

Scenario: Add a class that already exist - red path
	Given I have a "PHY002" in the data base 
	When I add the class "PHY002" in the data base
	Then I should get on the screen "Error class already exist."
