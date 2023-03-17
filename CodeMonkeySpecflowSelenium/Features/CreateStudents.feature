Feature: CreateStudents

@CreateJobOffers
Scenario: Create Students
	Given I navigate to StudentsApp to Create Students
	| Browser | BrowserVersion | OS      |
	| Edge    | 110.0.1587.46  | Windows |
	When I click Login to Create Students
	And StudentsApp Web should opened to Create Students
	And I hit Create Students Tab
	And Students Registration Form opened
	And I fill the Students First Name Field with Automated
	And I fill the Students Last Name Field with Student
	And I fill the Students Email Field with madslava50@gmail.com
	And I fill the Students Country Field with Croatia
	And I fill the Students Telephone Field with +62 888 1231 231
	And I fill the Students Address Field with Automated Street 123
	And I fill the Students University Field with Harvard University
	And I fill the Students IT Area Field with IT Technician
	And I fill the Students Date of Birth Field with 12/31/2000
	And I fill the Students City Field with Zagreb
	And I fill the Students Languages Field with Mandarin
	And I fill the Students Programming Languages Field with HTML
	And I fill the Students Agile Methodologies Field with Yes
	And I fill the Students Availability Field with On site
	And I hit Create Students Button
	Then I should redirected to Students List page
