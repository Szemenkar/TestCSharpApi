import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

/*Given('that I am on the product page', () => {
  // TODO: implement step
});*/

/* When('I choose the category {string}', (a) => {
  // TODO: implement step
});*/

Then('I should see the price {string} for the product {string}', (price, productName) => {
  cy.get('.product').contains('div.product', productName).find('.price').contains('Pris: ' + price + ' kr')
});

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/

/* No duplicate steps, this one already above
Then('I should see the price {string} for the product {string}', (a, b) => {});*/