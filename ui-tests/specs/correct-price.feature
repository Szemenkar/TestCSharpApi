Feature: As user I want to see the correct price for the product

Scenario: Displays the correct price for the chosen product
    Given that I am on the product page
    When I choose the category "Alla"
    Then I should see the price "3999" for the product "GeForce RTX Grafikkort"
    And I should see the price "899" for the product "Kingston SSD"
    And I should see the price "1399" for the product "Corsair 16 GB"
    And I should see the price "5499" for the product "Intel Core i9"
    And I should see the price "1699" for the product "Logitech Pro X Superlight"
    And I should see the price "3999" for the product "ThunderX3 XTC"
    And I should see the price "2299" for the product "Logitech G Pro 60"
    And I should see the price "4599" for the product "Nothing Phone (2a)"
    And I should see the price "549" for the product "Deltaco Powerbank 20000"
    And I should see the price "199" for the product "Nothing Phone Screen Protector"
    And I should see the price "2799" for the product "Samsung External 2TB"
    And I should see the price "599" for the product "WD Elements"
    And I should see the price "1699" for the product "Samsung External 1TB"
    And I should see the price "150" for the product "Presentkort 150kr"
    And I should see the price "250" for the product "Presentkort 250kr"
    And I should see the price "1000" for the product "Presentkort 1000kr"
    When I choose the category "Mobiltelefon"
    Then I should see the price "4599" for the product "Nothing Phone (2a)"
    And I should see the price "549" for the product "Deltaco Powerbank 20000"
    And I should see the price "199" for the product "Nothing Phone Screen Protector"