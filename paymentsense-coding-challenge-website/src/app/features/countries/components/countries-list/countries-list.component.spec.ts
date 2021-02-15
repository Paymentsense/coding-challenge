import { Shallow } from "shallow-render";
import { COUNTRY } from "src/app/testing/country.test-data";
import { CountriesModule } from "../../countries.module";
import { CountriesItemComponent } from "../countries-item/countries-item.component";
import { CountriesListComponent } from "./countries-list.component";

describe("CountriesListComponent", () => {
  let shallow: Shallow<CountriesListComponent>;

  beforeEach(() => {
    shallow = new Shallow(CountriesListComponent, CountriesModule);
  });

  it("should pass countries into children", async () => {
    const { findComponent } = await shallow.render({
      bind: { countries: [COUNTRY, COUNTRY] },
    });

    const countries = findComponent(CountriesItemComponent);

    expect(countries).toHaveFound(2);
  });
});
