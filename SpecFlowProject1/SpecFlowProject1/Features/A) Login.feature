Feature: A1) Login into adactinhotelapp.com

@sanity @DataSource:../data/login.xlsx
Scenario Outline: A1) Login with the valid credentials into the Website
	Given open website https://adactinhotelapp.com/
	When enter username <username> on login_username
	When enter password <password> on login_password
	Then click submit login_submit