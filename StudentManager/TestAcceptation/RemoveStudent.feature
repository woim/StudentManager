﻿Feature: RemoveStudent
	In order to remove a student from a class
	As a school administrator
	I want to be able to remove student from a class
	
Background: 
	Given I have the data base with
		| Class  | Student        | 
		| PHY001 | Thibodeau,Jean | 
		| PHY001 | Loiseau,Martin |		

@greenPath
Scenario: Remove a student from a class
	When I remove a student to the class
		| Class  | Student        | 
		| PHY001 | Thibodeau,Jean | 
	Then the data base should have those element
		| Class  | Student        | 
		| PHY001 | Loiseau,Martin |


@redPath
Scenario: Remove a student to a class in which it does not exist
	When I remove a student to the class 
		| Class  | Student    | 
		| PHY001 | Loup,Garou |
	Then I should get an error message "Error student do not exist."
	
@redPath
Scenario: Add a student to a class in which it already exist
	When I add a student to the class 
		| Class  | Student        | 
		| PHY001 | Thibodeau,Jean |
	Then I should get an error message "Error student already exist."

@redPath
Scenario: Remove a student without specifying the class
	When I remove a student to the class 
		| Class  | Student        | 
		|        | Thibodeau,Jean |
	Then I should get an error message "Error class not specified."
