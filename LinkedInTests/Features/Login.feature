Feature: Login

User logs in with valid credentials (username,password)
Home page will load after successful login

Scenario: Login with valid credentials
	Given User will be on the login page
	When User will enter username
	And  User will enter password
	And  User will click on login button
	Then User will be redirected to home page
