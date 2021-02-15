import { ActivatedRouteSnapshot } from "@angular/router";
import { Shallow } from "shallow-render";
import { CountriesModule } from "../countries.module";
import { CountriesFacade } from "../facades/countries.facade";
import { CountriesResolver } from "./countries.resolver";
describe("CountriesResolver", () => {
  let shallow: Shallow<CountriesResolver>;

  beforeEach(() => {
    shallow = new Shallow(
      CountriesResolver,
      CountriesModule
    ).mock(CountriesFacade, { getCountriesForPagination: () => undefined });
  });

  it("should call getCountriesForPagination when resolve is executed", () => {
    const { instance, inject } = shallow.createService();

    const routeSnapshot: Partial<ActivatedRouteSnapshot> = {
      queryParams: { page: 2, take: 30 },
    };

    const facade = inject(CountriesFacade);

    instance.resolve(routeSnapshot as ActivatedRouteSnapshot);

    expect(facade.getCountriesForPagination).toHaveBeenCalledWith(2, 30);
  });

  it("should call getCountriesForPagination with defaults when resolve is executed and there are no query params", () => {
    const { instance, inject } = shallow.createService();

    const routeSnapshot: Partial<ActivatedRouteSnapshot> = {
      queryParams: {},
    };

    const facade = inject(CountriesFacade);

    instance.resolve(routeSnapshot as ActivatedRouteSnapshot);

    expect(facade.getCountriesForPagination).toHaveBeenCalledWith(1, 10);
  });
});
