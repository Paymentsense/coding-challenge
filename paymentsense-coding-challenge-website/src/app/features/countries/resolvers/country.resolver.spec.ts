import { ActivatedRouteSnapshot } from "@angular/router";
import { Shallow } from "shallow-render";
import { CountriesModule } from "../countries.module";
import { CountriesFacade } from "../facades/countries.facade";
import { CountryResolver } from "./country.resolver";
describe("CountryResolver", () => {
  let shallow: Shallow<CountryResolver>;

  beforeEach(() => {
    shallow = new Shallow(
      CountryResolver,
      CountriesModule
    ).mock(CountriesFacade, { getCountry: () => undefined });
  });

  it("should call getCountry when resolve is executed", () => {
    const { instance, inject } = shallow.createService();

    const routeSnapshot: Partial<ActivatedRouteSnapshot> = {
      params: { code: "AAA" },
    };

    const facade = inject(CountriesFacade);

    instance.resolve(routeSnapshot as ActivatedRouteSnapshot);

    expect(facade.getCountry).toHaveBeenCalledWith("AAA");
  });
});
