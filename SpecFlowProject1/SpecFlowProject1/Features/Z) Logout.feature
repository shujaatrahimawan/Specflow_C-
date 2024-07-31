Feature: Z1) Logout from the adactinhotelapp.com

@sanity
Scenario Outline: Z1) Logout from the Website
	Given click on logout "logout_button"
	When wait for 5 seconds
	When verify login screen "You have successfully logged out. Click here to login again" from "logout_message"
