import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { take } from "rxjs/operators";
import {
  CountriesClient,
  Country,
  CountryForPagination,
  PaginationMeta,
} from "../../../core/api-clients";

@Injectable({
  providedIn: "root",
})
export class CountriesFacade {
  private countriesSubject$ = new Subject<CountryForPagination[]>();
  private paginationMetaSubject$ = new Subject<PaginationMeta>();
  private countrySubject$ = new Subject<Country>();

  countries$ = this.countriesSubject$.asObservable();
  paginationMeta$ = this.paginationMetaSubject$.asObservable();
  country$ = this.countrySubject$.asObservable();

  constructor(private readonly client: CountriesClient) {}

  public getCountriesForPagination(page: number, numToTake: number) {
    this.client
      .countries_GetAllCountriesForPagination(page, numToTake)
      .pipe(take(1))
      .subscribe((countriesResponse) => {
        this.countriesSubject$.next(countriesResponse.countries);
        this.paginationMetaSubject$.next(countriesResponse.meta);
      });
  }

  public getCountry(code: string) {
    // set the country to null, so the loading indicator appears
    this.countrySubject$.next(null);
    this.client
      .countries_GetByCode(code)
      .pipe(take(1))
      .subscribe((country) => {
        this.countrySubject$.next(country);
      });
  }
}
