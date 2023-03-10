Feature: DisplayJobOffers

@DisplayJobOffers
Scenario: Display JobOffers
	Given I navigate to JobOffersApp to Display Job
	| Browser | BrowserVersion | OS      |
	| Edge    | 110.0.1587.46  | Windows |
	When I click Login to Display Job
	And JobOffersApp Web should opened to Display Job
	And Job Offer List page opened to Display Job
	And Filter by Title is activated using An Automated Job
	And Filter by Company is activated using An Automated Company
	And Filter by Status is activated using Open
	And Filter by Date is activated using Today date
	And Remove Filter is chosen
	And Manage Button is Clickable
	And Archive Button is Clickable
	And Delete Button is Clickable
	Then 
