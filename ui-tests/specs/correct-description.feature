Feature: As user I want to see the correct description for the product

Scenario Outline: Displays the correct description for the chosen product
    Given that I am on the product page
    When I choose the category "<category>"
    Then I should see the description "<description>" for the product "<product>"

    Examples:
        | category         | description                               | product                        |
        | Datorkomponenter | Grafikkort                                | GeForce RTX                    |
        | Datorkomponenter | Hårddisk SSD                              | Kingston SSD                   |
        | Datorkomponenter | Internminne                               | Corsair 16 GB                  |
        | Datorkomponenter | Processor                                 | Intel Core i9                  |
        | Datortillbehör   | Gaming-mus                                | Logitech Pro X Superlight      |
        | Datortillbehör   | Gamingstol, färg svart                    | ThunderX3 XTC                  |
        | Datortillbehör   | Tangentbord                               | Logitech G Pro 60              |
        | Mobiltelefon     | Mobiltelefon                              | Nothing Phone (2a)             |
        | Mobiltelefon     | Powerbank                                 | Deltaco Powerbank 20000        |
        | Mobiltelefon     | Skärmskydd                                | Nothing Phone Screen Protector |
        | Extern lagring   | Extern lagring 2 TB, Gen2                 | Samsung External 2TB           |
        | Extern lagring   | Extern lagring 1 TB, Gen1                 | WD Elements                    |
        | Extern lagring   | Extern lagring 1 TB, Gen2                 | Samsung External 1TB           |
        | Presentkort      | Presentkort till våra produkter, 150 SEK  | Presentkort 150kr              |
        | Presentkort      | Presentkort till våra produkter, 250 SEK  | Presentkort 250kr              |
        | Presentkort      | Presentkort till våra produkter, 1000 SEK | Presentkort 1000kr             |