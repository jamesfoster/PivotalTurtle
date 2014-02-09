Feature: StoreApiToken
	In order to avoid entering my api token every time
	As a user
	I want to allow the plugin to store my api key

@mytag
Scenario: Retrieving the stored token
	Given I am not logged in
	And my api token is stored
	When I press the Select Stories button
	Then I should not be asked to log in
	And I should be logged in
