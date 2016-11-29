Feature: RemoveClass
	In order to update the data base
	As a school administrator
	I want to be able remove a class from data base
	
Background: 
	Given I have the data base with
	| Class  |
	| PHY001 |
	| CHI002 |
	

@greenPath
Scenario: Remove a class  
	When I remove the class "PHY001" in the data base
	Then the data base should have those element
		| Class  | 
		| CHI002 | 


@redPath
Scenario Outline: Remove a class with a bad name format
	When I remove the class "<Class>" in the data base
	Then I should get an error message "Error class name format incorrect."

	Examples: 
	| Class   | 
	| MA      |
	| MAGH1   |
	| MAT0002 | 


@redPath
Scenario: Remove a class that do not exist
	When I remove the class "BIO002" in the data base
	Then I should get an error message "Error class do not exist."
