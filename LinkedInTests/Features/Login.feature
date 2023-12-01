Feature: Login

User logs in with valid credentials (username,password)
Home page will load after successful login

Background: Given User will be on the login page

@positive
Scenario: Login with valid credentials
	When User will enter username
	And  User will enter password
	And  User will click on login button
	Then User will be redirected to home page

@negative
Scenario: Login with invalid credentials
	When User will enter username
	And  User will enter password
	And  User will click on login button
	Then Error message for password length should be thrown

@regression
Scenario: Check for Password Hidden Display
	When User will enter password
	And  User will click on show button in the password text box
	Then The password characters should be shown

@regression
Scenario: Check for Password Show Display
	When User will enter password
	And  User will click on show button in the password text box
	And  User will click on hide button in the password text box
	Then The password characters should not be shown

