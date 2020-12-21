import { Injectable } from "@angular/core";
import { Country } from "../models/country";
import { EMPTY } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { shareReplay,  catchError } from "rxjs/operators";
import { untilDestroyed, UntilDestroy } from "@ngneat/until-destroy";
const API_ENDPOINT = "https://localhost:44341/country/all";

@Injectable({
  providedIn: "root",
})
@UntilDestroy()
export class CountryService {
  private selectedCountry: any;
  cache = {};
  constructor(private httpClient: HttpClient) {}

  public GetAllCountries() {
    return this.httpClient.get<Country[]>(API_ENDPOINT).pipe(
      shareReplay(1),
      catchError((err) => {
        return EMPTY;
      })
    );
  }

  public getSelectedCountry() {
    return this.selectedCountry;
  }
  public setSelectedCountry(country) {
     this.selectedCountry=country;
  }
}
