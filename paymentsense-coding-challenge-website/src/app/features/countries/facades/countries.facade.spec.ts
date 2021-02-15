import { of } from "rxjs";
import { filter, take } from "rxjs/operators";
import { Shallow } from "shallow-render";
import { CountriesClient } from "src/app/core/api-clients";
import { COUNTRY } from "src/app/testing/country.test-data";
import {
  PAGINATION_META,
  PAGINATION_RESPONSE,
} from "src/app/testing/pagination-response.test-data";
import { CountriesModule } from "../countries.module";
import { CountriesFacade } from "./countries.facade";

describe("CountriesFacade", () => {
  let shallow: Shallow<CountriesFacade>;

  beforeEach(() => {
    shallow = new Shallow(CountriesFacade, CountriesModule).mock(
      CountriesClient,
      {
        countries_GetAllCountriesForPagination: () => of(PAGINATION_RESPONSE),
        countries_GetByCode: () => of(COUNTRY),
      }
    );
  });

  it("should load countries$ when getCountriesForPagination is called", (done) => {
    const { instance } = shallow.createService();

    const expectedCountries = [COUNTRY];

    instance.countries$.pipe(take(1)).subscribe((result) => {
      expect(result).toEqual(expectedCountries);
      done();
    });

    instance.getCountriesForPagination(1, 10);
  });

  it("should load paginationMeta$ when getCountriesForPagination is called", (done) => {
    const { instance } = shallow.createService();

    const expectedPaginationMeta = { ...PAGINATION_META };

    instance.paginationMeta$.pipe(take(1)).subscribe((result) => {
      expect(result).toEqual(expectedPaginationMeta);
      done();
    });

    instance.getCountriesForPagination(1, 10);
  });

  it("should load country$ when getCountry is called", (done) => {
    const { instance } = shallow.createService();

    const expectedCountry = { ...COUNTRY };

    instance.country$
      .pipe(
        take(2),
        filter((country) => !!country)
      )
      .subscribe((result) => {
        expect(result).toEqual(expectedCountry);
        done();
      });

    instance.getCountry("code");
  });
});
