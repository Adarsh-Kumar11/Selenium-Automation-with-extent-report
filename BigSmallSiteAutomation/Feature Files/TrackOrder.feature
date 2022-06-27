Feature: TrackOrder
	
Scenario: Check tracking Functionality
	Given the homepage of the website
	When user click on track your order link
	And user enter valid email
	And user enter invalid track id
	And user click on find order
	Then the error message must be displayed