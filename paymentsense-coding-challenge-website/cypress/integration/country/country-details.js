describe("Country DEtails E2E tests", () => {

  it("should visit country detail page", () => {
    cy.visit("country");
  });

  it("should visit country detail page when I click first row", () => {
    cy.get('tbody > :nth-child(1) > .cdk-column-flag').click();
    cy.url().should('include', '/country-detail')
  });

  
  it("should contain Countries Details in header ", () => {
    cy.get("h2").contains("Country Details");
  });

  it("should be Afghanistan  for  Country Name", () => {
    cy.get(':nth-child(2) > .display-values > p').contains("Afghanistan");
  });

  it("should be Afghanistan  for  Country Name", () => {
    cy.get(':nth-child(3) > .display-values > p').contains("27,657,145");
  });

});
