import { ProgressSpinner } from "primeng/progressspinner";
import { BehaviorSubject } from "rxjs";
import { Shallow } from "shallow-render";
import { Country } from "src/app/core/api-clients";
import { COUNTRY } from "src/app/testing/country.test-data";
import { CountryInformationComponent } from "../../components/country-information/country-information.component";
import { CountriesModule } from "../../countries.module";
import { CountriesFacade } from "../../facades/countries.facade";
import { CountryComponent } from "./country.component";

describe("CountryComponent", () => {
  let shallow: Shallow<CountryComponent>;

  let countryBS$: BehaviorSubject<Country>;

  beforeEach(() => {
    countryBS$ = new BehaviorSubject(null);

    shallow = new Shallow(
      CountryComponent,
      CountriesModule
    ).mock(CountriesFacade, { country$: countryBS$.asObservable() });
  });

  it("should render Country Information when there is emitted from the observable", async () => {
    countryBS$.next(COUNTRY);

    const { findComponent } = await shallow.render();

    expect(findComponent(CountryInformationComponent)).toHaveFoundOne();
  });

  it("should render the spinner when there is no country from the observable", async () => {
    const { findComponent } = await shallow.render();

    expect(findComponent(ProgressSpinner)).toHaveFoundOne();
  });
});
