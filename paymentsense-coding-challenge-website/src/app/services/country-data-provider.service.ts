import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";
import { Country } from "../models/country";

@Injectable({
  providedIn: "root",
})
export class CountryDataProviderService {
  constructor(private httpClient: HttpClient) {}

  public getCountryList(): Observable<Country[]> {
    return this.httpClient
      .get("https://localhost:44339/PaymentsenseCodingChallenge/countries/list")
      .pipe(map((data: any) => data));
  }
}
