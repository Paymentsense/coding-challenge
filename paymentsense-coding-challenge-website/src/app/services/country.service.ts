import { Injectable } from "@angular/core";
import { Country } from "../models/country";
import { EMPTY, Observable, BehaviorSubject } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { shareReplay, catchError, finalize } from "rxjs/operators";
import { untilDestroyed, UntilDestroy } from "@ngneat/until-destroy";
import { environment as env } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
@UntilDestroy()
export class CountryService {
  private selectedCountry: any;
  private selectedCountrySource = new BehaviorSubject(this.selectedCountry);
  currentCountry = this.selectedCountrySource.asObservable();

  constructor(private httpClient: HttpClient) {}

  public GetAllCountries(): Observable<Country[]> {
    return this.httpClient
      .get<Country[]>(env.api_endpoint + "country/all")
      .pipe(
        catchError((err) => {
          return EMPTY;
        }),
        finalize(() => console.log("call finished"))
      );
  }

  setSelectedCountry(country: string) {
    this.selectedCountrySource.next(country);
  }
}
