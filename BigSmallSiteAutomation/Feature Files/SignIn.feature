Feature: SignIn

Scenario Outline: Login into the site with credentials
	Given the homepage of the website
	When user click on sign In buttton
	And user enter <id> and <password>
	And user click on sign In button
	Then the user must login to the site

	Examples: 
	| id                         | password     |
	| swastikverma1993@gmail.com | @Swastik1993 |