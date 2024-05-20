Feature: As user I want to see the correct products when I choose the category "Datorkomponenter"

Scenario: Checks that the category is "Datorkomponenter" when chosen and correct products are shown
    Given that I am on the product page
    When I choose the category "Datorkomponenter"
    Then I should see the product "GeForce RTX"
    And I should see the product "Kingston SSD"
    And I should see the product "Corsair 16 GB"
    And I should see the product "Intel Core i9"