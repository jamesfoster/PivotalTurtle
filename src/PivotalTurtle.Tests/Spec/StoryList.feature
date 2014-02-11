Feature: Story list
	In order to associate a checkin with a story
	As a user
	I want to be able to select a story from a list

Scenario: Selecting a story
	Given I am logged in
	And I am assigned to at least one project in PivotalTracker
	And I am assigned to at least one story in PivotalTracker
	When I press the Select Stories button
	Then I should see my list of stories
	When I select a story
	And I click the OK button
	Then the new commit message should contain the story id