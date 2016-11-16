Feature: ListStudent
	In order to know student names enrolled in a specific course
	As a teacher
	I want to list the student in a course

@mytag
Scenario Outline: list student - green path
	Given I have a <Student1> and <Student2> in <class>
	When I run this command "-f testDB -listStudent --class=<class>"
	Then I should get on the screen "Michel Jean\nThibodeau Gustave\n"
	
	Examples: 
		| Student1 | Student2  | class  |
		| Michel   | Thibodeau | CHI001 |
