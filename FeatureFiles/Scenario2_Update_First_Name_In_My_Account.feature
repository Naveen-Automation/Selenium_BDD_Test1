Feature: Update My Personal Info section
	1. Launch browser and navigate to the application
	2. Login to my store
	3. Update peronal information (First Name) and save it
	4. Verify if the success message

@UpdateTest , @PersonalAccountTest
Scenario: Update personal information (First Name) in my account
	When I launch the browser and navigate to "My Store" application
	Then I should see "Landing" page
	When I click on "Sign In" button on "Landing" page
	Then I should see "Login" page
	When I enter sign in details in "Login" page and click on "Sign In" button
	Then I should see "Home" page
	When I click on "My Personal Information" button on "Home" page
	And I key the below details in "My Personal Information" screen and I click on "Save" button
		| FirstName   |
		| Veer Naveen |
	Then I should see a success message on "My Personal Information" screen