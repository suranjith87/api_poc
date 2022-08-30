@API
Feature: API_Carbon_Registry
		As a user, 
		I want to verify that these carbon credits are certified and registered with a carbon credits registry

@Regression
Scenario: API-TC01-Verify_that_the_catagory_name
	Given I have access the api end point of registry
	When I access the details of catagory
	Then I should be able to catagory name as "Carbon credits"

@Regression
Scenario: API-TC02-Verify_that_the_catagory_can_re-list
	Given I have access the api end point of registry
	When I access the details of catagory
	Then I should be able to view catagory re-list status as "true" 

@Regression
Scenario Outline: API-TC03-Verify_that_the_catagory_name
	Given I have access the api end point of registry
	When I access the details of catagory
	Then I should be able to view promotion name as "<Name>" has a Description that contains the text "<Description>"

	Examples:
	| Name    | Description               |
	| Gallery | Good position in category |