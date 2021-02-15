import { Shallow } from "shallow-render";
import { COUNTRY } from "src/app/testing/country.test-data";
import { CountriesModule } from "../../countries.module";
import { CountryInformationComponent } from "./country-information.component";

describe("CountryInformationComponent", () => {
  let shallow: Shallow<CountryInformationComponent>;

  beforeEach(() => {
    shallow = new Shallow(CountryInformationComponent, CountriesModule);
  });

  it("should render information", async () => {
    const { find } = await shallow.render({
      bind: { country: COUNTRY },
    });

    expect(find("[data-test=name]").nativeElement.innerText).toEqual(
      COUNTRY.name
    );
    expect(find(".flag").attributes.src).toEqual(COUNTRY.flag);
    expect(find("[data-test=capital]").nativeElement.innerText).toEqual(
      COUNTRY.capital
    );
    expect(find("[data-test=language]")[0].nativeElement.innerText).toEqual(
      COUNTRY.languages[0].name
    );
    expect(find("[data-test=language]")[1].nativeElement.innerText).toEqual(
      COUNTRY.languages[1].name
    );
    expect(find("[data-test=population]").nativeElement.innerText).toContain(
      COUNTRY.population
    );
    expect(find("[data-test=timezone]")[0].nativeElement.innerText).toEqual(
      COUNTRY.timezones[0]
    );
    expect(find("[data-test=currency]")[0].nativeElement.innerText).toEqual(
      `${COUNTRY.currencies[0].name} (${COUNTRY.currencies[0].symbol})`
    );
    expect(find("[data-test=border]")[0].nativeElement.innerText).toEqual(
      COUNTRY.borders[0]
    );
  });
});
