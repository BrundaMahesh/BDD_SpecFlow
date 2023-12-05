Feature: SearchAndAddToCart

@E2E-Search_And_Add_To_Cart
Scenario: Search for products
	Given User will be on the home page
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext | 
	| water      | 

@E2E-Search_And_Add_To_Cart
Scenario Outline: Check_For_Title_After_Search
	Then The heading should have '<searchtext>'
	* Title should have '<searchtext>'
Examples: 
	| searchtext | 
	| water      | 