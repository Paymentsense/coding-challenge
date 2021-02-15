import { of } from "rxjs";
import { Shallow } from "shallow-render";
import { COUNTRY } from "src/app/testing/country.test-data";
import { CountriesListComponent } from "../../components/countries-list/countries-list.component";
import { CountriesModule } from "../../countries.module";
import { CountriesFacade } from "../../facades/countries.facade";
import { CountriesComponent } from "./countries.component";

describe("CountriesComponent", () => {
  let shallow: Shallow<CountriesComponent>;

  beforeEach(() => {
    shallow = new Shallow(
      CountriesComponent,
      CountriesModule
    ).mock(CountriesFacade, { countries$: of([COUNTRY]) });
  });

  it("should pass countries into child", async () => {
    const { findComponent } = await shallow.render();

    const countriesList = findComponent(CountriesListComponent);

    expect(countriesList.countries).toEqual([COUNTRY]);
  });
});
