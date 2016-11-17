Feature: RemoveStudent
	In order to remove a student from a class
	As a school administrator
	I want to be able to remove student from a class
	
@mytag
Scenario Outline: Remove a student from a class - green path
	Given I have a <Class> with one student <Student1> 
	When I enter the command "-f testDB -RemoveStudent --Class=<Class> -n Thibodeau -p Gustave"
	Then the modified database should be 

	Examples: 
		| Student1          | Class  |
		| Thibodeau,Gustave | CHI001 |


Scenario Outline: Remove a student to a class in which it does not exist - red path
	Given I have a <Class> with one student <Student1> 
	When I enter the command "-f testDB -RemoveStudent --Class=<Class> -n Thibodeau -p Gustave"
	Then I should get on the screen "Error student do not exist."

	Examples: 
		| Student1          | Class  |
		| Thibodeau,Gustave | CHI001 |


Scenario Outline: Remove a student without specifying the class - red path
	Given I have a <Class> with one student <Student1> 
	When I enter the command "-f testDB -RemoveStudent -n Thibodeau -p Gustave"
	Then I should get on the screen "Error class not specified."

	Examples: 
		| Student1          | Class  |
		| Thibodeau,Gustave | CHI001 |
