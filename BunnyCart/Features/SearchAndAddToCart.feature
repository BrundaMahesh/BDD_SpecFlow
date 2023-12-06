Feature: SearchAndAddToCart

@E2E-Search_And_Add_To_Cart
Scenario Outline: Search for products
	Given User will be on the home page
	When User will type the '<searchtext>' in the search box
	Then Search results are loaded in the same page with '<searchtext>'
	Then The heading should have '<searchtext>'
	* Title should have '<searchtext>'
	When User selects a '<productno>'
	Then Product page is loaded
	When User click on Net Pot type
	When User click on Add to Cart
	Then Modal will appear
Examples: 
	| searchtext | productno | 
	| water      | 1         | 

#@E2E-Search_And_Add_To_Cart
#Scenario Outline: 2 Select a particular product
#	Given Search page is loaded
#	When User selects a '<productno>'
#	Then Product page is loaded
#Examples: 
#	| productno | 
#	| 1         | 