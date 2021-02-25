Feature: Orders
	1. Launch browser and navigate to the application
	2. Verify any element on the page to confirm

@OrdersTest , @TShirtOrdersTest
Scenario: Order T-Shirt and verify in order history
	When I launch the browser and navigate to "My Store" application
	Then I should see "Landing" page
	When I click on "Sign In" button on "Landing" page
	Then I should see "Login" page
	When I enter sign in details in "Login" page and click on "Sign In" button
	Then I should see "Home" page

	When I click on "TShirts" button on "Home" page
	Then I should see "TShirts" page
	When I click on "In Stock" button on "TShirts" page
