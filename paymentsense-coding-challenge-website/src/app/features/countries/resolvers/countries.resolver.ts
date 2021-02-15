import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable, of } from "rxjs";
import { CountriesFacade } from "../facades/countries.facade";
import { getPageTakeFromParams } from "../functions/route.functions";

@Injectable({ providedIn: "root" })
export class CountriesResolver implements Resolve<any> {
  constructor(private readonly countriesFacade: CountriesFacade) {}

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    const { page, take } = getPageTakeFromParams(route);

    this.countriesFacade.getCountriesForPagination(page, take);
    return of({});
  }
}
