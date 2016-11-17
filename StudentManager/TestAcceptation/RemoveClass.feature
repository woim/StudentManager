Feature: RemoveClass
	In order to update the data base
	As a school administrator
	I want to be able remove a class from data base
	
@mytag
Scenario Outline: Remove a class - green path
	Given I have 2 classes <Class1> and <Class2> in the data base  
	When I enter the command "-f testDB -removeClass <Class2>"
	Then the modified database should be 

	Examples: 
		| Class1 | Class2 | 
		| PHY001 | MAT002 |


Scenario Outline: Remove a class with a bad name format - red path
	Given I have one "PHY002" in the data base
	When I enter the command "-f testDB -removeClass <Class>"
	Then I should get on the screen "Error class name format incorrect."

	Examples: 
		| Class  | 
		| MA     |
		| MAGH1  |
		| MAT002 | 

Scenario: Remove a class that does not exist - red path
	Given I have a "PHY002" in the data base 
	When I enter the command "-f testDB -addClass CHI001"
	Then I should get on the screen "Error class do not exist."
