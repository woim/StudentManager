Feature: ListStudent
	In order to know student names enrolled in a specific course
	As a teacher
	I want to list the student in a course

@mytag
Scenario Outline: list student - green path
	Given I have a <Student1> and <Student2> in <Class>
	When I run this command "-f testDB -listStudent --Class=<Class>"
	Then I should get on the screen "<Student1>\n<Student2>"
	
	Examples: 
		| Student1          | Student2    | Class  |
		| Thibodeau,Gustave | Michel,Jean | CHI001 |


Scenario Outline: list student in alphabetic order - green path
	Given I have a <Student1> and <Student2> in <Class>
	When I run this command "-f testDB -listStudent -s --Class=<Class>"
	Then I should get on the screen "<Student2>\n<Student1>"
	
	Examples: 
		| Student1          | Student2    | Class  |
		| Thibodeau,Gustave | Michel,Jean | CHI001 |


Scenario Outline: list student - red path
	Given I have a <Student1> and <Student2> in <Class>
	When I run this command "-f testDB -listStudent"
	Then I should get on the screen "Error Class not specified.\n"
	
	Examples: 
		| Student1          | Student2    | Class  |
		| Thibodeau,Gustave | Michel,Jean | CHI001 |