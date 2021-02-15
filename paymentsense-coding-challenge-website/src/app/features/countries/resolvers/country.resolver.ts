import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable, of } from "rxjs";
import { CountriesFacade } from "../facades/countries.facade";

@Injectable({ providedIn: "root" })
export class CountryResolver implements Resolve<any> {
  constructor(private readonly countriesFacade: CountriesFacade) {}

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    const code = route.params.code;

    this.countriesFacade.getCountry(code);
    return of({});
  }
}
