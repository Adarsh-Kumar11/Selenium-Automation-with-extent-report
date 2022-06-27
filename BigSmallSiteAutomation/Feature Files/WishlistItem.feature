Feature: WishlistItem
	
Scenario: Adding item to wishlist
	Given the homepage of the website
	When user click on item
	And user click on add to wishlist
	And user navigate to wishlist
	Then the item must be added