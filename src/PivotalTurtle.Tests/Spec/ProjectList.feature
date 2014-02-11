Feature: Projects list
	In order to select a story
	As a user
	I want to select a project

Scenario: I see a list of projects I am assigned to
	Given I am logged in
	And I am assigned to at least one project in PivotalTracker
	When I press the Select Stories button
	Then I should see a list of projects

Scenario: I'm not assigned to any projects
	Given I am logged in
	And I am not assigned to any projects in PivotalTracker
	When I press the Select Stories button
	Then I should not see a list of projects
	And I should see a message to create a project on PivotalTracker

Scenario: Failure to log in
	Given I am not logged in
	When I press the Select Stories button
	And I enter invalid credentials
	And I click the Log in button
	Then I should not see a list of projects
	And I should see an authentication failure message
