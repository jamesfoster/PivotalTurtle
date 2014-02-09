Feature: Log in
	In order to fetch a list of projects
	As a user
	I want to be able to log in to PivotalTracker

Scenario: Successfully logging in
	Given I am not logged in
	When I press the Select Stories button
	Then I should be asked to log in
	When I enter valid credentials
	And I click the Log in button
	Then I should be logged in

Scenario: Trying to log in with invalid credentials
	Given I am not logged in
	When I press the Select Stories button
	Then I should be asked to log in
	When I enter invalid credentials
	And I click the Log in button
	Then I should not be logged in

Scenario: Bypass log in if already logged in
	Given I am logged in
	When I press the Select Stories button
	Then I should not be asked to log in
