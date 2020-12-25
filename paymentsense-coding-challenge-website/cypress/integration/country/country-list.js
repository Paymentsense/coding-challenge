describe("Country List E2E tests", () => {


    it("should visit  country list page", () => {
    cy.visit("country");
  });
  it("should contain Countries in header ", () => {
    cy.get("h1").contains("Countries");
  });

  it("should contain Flag in table header ", () => {
    cy.get(".mat-header-row > .cdk-column-flag").contains("Flag");
  });

  it("should contain Name in table header ", () => {
    cy.get(".mat-header-row > .cdk-column-name").contains("Name");
  });
  it("should change table size to 50", () => {
    cy.get(".mat-select-value").click();
    cy.get("#mat-option-2 > .mat-option-text").click();

    cy.get(".mat-select-value").contains("50");
  });
  
});
