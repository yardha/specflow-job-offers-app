Feature: CreateJobOffers

@CreateJobOffers
Scenario: Create Job Offer
	Given I navigate to JobOffersApp to Create Job
	| Browser | BrowserVersion | OS      |
	| Edge    | 110.0.1587.46  | Windows |
	When I click Login to Create Job
	And JobOffersApp Web should opened to Create Job
	And I hit Create Job Offer Tab
	And Job Registration Form opened
	And I fill the Job Title Field with An Automated Job
	And I fill the Company Name Field with An Automated Company
	And I fill the Description Field with An Automated Description
	And I fill the Degree Field with IT Technician
	And I fill the Programming Languages Field with HTML
	And I fill the Languages Field with Mandarin
	And I fill the Agile Methodologies Field with Yes
	And I fill the City Field with Zagreb
	And I fill the Country Field with Croatia
	And I fill the Availability Field with On site
	And I hit Create Job Offer Button
	Then I should redirected to Job Offer List page
	And Title should be An Automated Job
	And Company should be An Automated Company
	And Status should be Open
	And Date should be Today
