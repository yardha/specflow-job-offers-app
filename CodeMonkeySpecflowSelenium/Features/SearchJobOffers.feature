Feature: SearchJobOffers

@SearchJobOffers
Scenario: Search Job Offer
	Given I navigate to JobOffersApp to Search Job
	| Browser | BrowserVersion | OS      |
	| Edge    | 110.0.1587.46  | Windows |
	When I click Login to Search Job
	And JobOffersApp Web should opened to Search Job
	And Job Offer List page opened to Search Job
	And I hit Search for Candidate
	Then Result should be displayed
	And Position should be An Automated Job
	And Company Name should be An Automated Company
	And Selected Student should be Automated Student
	And Click Notify Button to send the email
	Then The status of the Job Offer became Closed
