Feature: AddClass
	In order to store the class in the data base
	As a school administrator
	I want to be able to add class to data base
	
Background: 
	Given I have the data base with
	| Class  |
	| PHY001 |
	

@greenPath
Scenario: Add a class  
	When I add the class "MAT002" in the data base
	Then the modified database should have classes "PHY001" and "MAT002"


@redPath
Scenario Outline: Add a class with a bad name format
	When I add the class "<Class>" in the data base
	Then I should get on the screen the error message "Error class name format incorrect."

	Examples: 
	| Class   | 
	| MA      |
	| MAGH1   |
	| MAT0002 | 


@redPath
Scenario: Add a class that already exist
	When I add the class "PHY001" in the data base
	Then I should get on the screen the error message "Error class already exist."