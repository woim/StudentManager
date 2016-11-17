Feature: ListClass
	In order to know the class of the school year
	As a school administrator
	I want to list the class name in the data base

@mytag
Scenario Outline: list classes - green path
	Given I have a <class1> and <class2> and <class3>
	When I run this command "-f testDB -listCalss"
	Then I should get on the screen "<class1>\n<class2>\n<class3>\n"
	
	Examples: 
		| Class1 | Class2 | Class3 |
		| PHY001 | MAT002 | CHI001 |


Scenario Outline: list classes sort - red path
	Given I have a <class1> and <class2> and <class3>
	When I run this command "-f testDB -listCalss -s"
	Then I should get on the screen "<class3>\n<class2>\n<class1>\n"
	
	Examples: 
		| Class1 | Class2 | Class3 |
		| PHY001 | MAT002 | CHI001 |