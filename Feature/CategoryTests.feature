Feature: CategoryTests
  As a restaurant administrator
  I want to be able to create, delete and update categories
  So that customers know what categories exist in menus

  @categoryTest
  Scenario: Create a category
    Given an admin
    Given I have specified a category
    When I create the category
    Then the category has been created
    And I can read the category returned

     #  @categoryTest
  #Scenario: Admins can delete category
    #  Given an admin
    #  And a category in the menu already exists
    #  When I delete the category
   #  Then the category has been deleted

  #     @categoryTest
#Scenario: Admins can update category 
#    Given a user
#    And a menu already exists
#    And a category in the menu already exists
#    When I update the category
#    Then the category has been updated




        