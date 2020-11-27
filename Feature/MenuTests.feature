Feature: MenuTests
  As a restaurant administrator
  I want to be able to create, delete, update menus
  So that customers know what we have on offer

  @menuTest
  Scenario: Create a menu
    Given an admin
    And I have specified a full menu
    When I create the menu
    Then the menu has been created
    And I can read the menu returned

  #  Scenario: Admin can delete menus
 #   Given an admin
 #  And a menu already exists
 #  When I delete the menu
   # Then the menu has been deleted

  #    @menuTest
  # Scenario: Admin can update existing menus
   # Given an admin
   # And a menu already exists
   # When I send an update menu request
  # Then the menu is updated correctly


 