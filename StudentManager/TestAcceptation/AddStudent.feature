Feature: AddStudent
	In order to fill a class with students
	As a school administrator
	I want to be able to add student to a class


Background: 
	Given I have the data base with
		| Class  | Student        | 
		| PHY001 | Thibodeau,Jean | 


@greenPath
Scenario: Add a student to a class
	When I add a student to the class 
		| Class  | Student        | 
		| PHY001 | Loiseau,Martin | 		
	Then the data base should have those element
		| Class  | Student        | 
		| PHY001 | Thibodeau,Jean | 
		| PHY001 | Loiseau,Martin | 


@redPath
Scenario: Add a student to a class in which it already exist
	When I add a student to the class 
		| Class  | Student        | 
		| PHY001 | Thibodeau,Jean |
	Then I should get an error message "Error student already exist."


@redPath
Scenario: Add a student without specifying the class
	When I add a student to the class 
		| Class  | Student        | 
		|        | Thibodeau,Jean |
	Then I should get an error message "Error class not specified."