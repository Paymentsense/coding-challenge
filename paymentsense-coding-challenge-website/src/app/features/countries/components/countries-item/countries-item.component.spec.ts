import { Shallow } from "shallow-render";
import { COUNTRY } from "src/app/testing/country.test-data";
import { CountriesModule } from "../../countries.module";
import { CountriesItemComponent } from "./countries-item.component";

describe("CountriesItemComponent", () => {
  let shallow: Shallow<CountriesItemComponent>;

  beforeEach(() => {
    shallow = new Shallow(CountriesItemComponent, CountriesModule);
  });

  it("should render item", async () => {
    const { find } = await shallow.render({
      bind: { country: COUNTRY },
    });

    expect(find("[data-test=name]").nativeElement.innerText).toEqual(
      COUNTRY.name
    );
    expect(find(".flag").attributes.src).toEqual(COUNTRY.flag);
  });
});
