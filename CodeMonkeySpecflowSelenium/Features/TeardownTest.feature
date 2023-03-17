Feature: TeardownTest

@TeardownTest
Scenario: Teardown Test
	Given I navigate to StudentsApp to Remove Student
	| Browser | BrowserVersion | OS      |
	| Edge    | 110.0.1587.46  | Windows |
	When I click Login to Remove Student
	And StudentsApp Web should opened to Remove Student
	And Search for a student named Automated
	And Delete the student
	Then Student list is not storing a student named Automated Student
