Feature: SearchItem
	
Scenario: Search item and add to cart
	Given the homepage of the website
	When user enter value in search tab
	And user click on related item
	And user click on add to cart
	Then verify the item added