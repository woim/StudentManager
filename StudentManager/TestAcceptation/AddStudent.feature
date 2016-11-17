Feature: AddStudent
	In order to fill a class with student
	As a school administrator
	I want to be able to add student to a class
	
@mytag
Scenario Outline: Add a student to a class - green path
	Given I have a <Class> with one student <Student1> 
	When I enter the command "-f testDB -addStudent --Class=<Class> -n Loup -p Garou"
	Then the modified database should be 

	Examples: 
		| Student1          | Class  |
		| Thibodeau,Gustave | CHI001 |


Scenario Outline: Add a student to a class in which it already exist - red path
	Given I have a <Class> with one student <Student1> 
	When I enter the command "-f testDB -addStudent --Class=<Class> -n Thibodeau -p Gustave"
	Then I should get on the screen "Error student already exist."

	Examples: 
		| Student1          | Class  |
		| Thibodeau,Gustave | CHI001 |


Scenario Outline: Add a student without specifying the class - red path
	Given I have a <Class> with one student <Student1> 
	When I enter the command "-f testDB -addStudent -n Thibodeau -p Gustave"
	Then I should get on the screen "Error class not specified."

	Examples: 
		| Student1          | Class  |
		| Thibodeau,Gustave | CHI001 |
