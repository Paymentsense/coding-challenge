import { CountryDataProviderService } from "./../services/country-data-provider.service";
import { Component, OnInit } from "@angular/core";
import { Country } from "../models/country";
import { Subject } from "rxjs";
import { takeUntil, tap, catchError, finalize } from "rxjs/operators";

@Component({
  selector: "country-list",
  templateUrl: "./country-list.component.html",
  styleUrls: ["./country-list.component.scss"],
})
export class CountryListComponent implements OnInit {
  public countryList: Country[] = [];
  public columnsToDisplay: string[] = ["flag", "name"];
  public loading = false;
  private unsubscribe$ = new Subject<boolean>();

  constructor(private countryDataProviderService: CountryDataProviderService) {}

  ngOnInit(): void {
    this.getCountryList();
  }

  getCountryList() {
    this.loading = true;
    this.countryDataProviderService
      .getCountryList()
      .pipe(
        takeUntil(this.unsubscribe$),
        tap((data: Country[]) => {
          this.countryList = data;
        }),
        catchError((error: any) => {
          console.error(error);
          return null;
        }),
        finalize(() => {
          this.loading = false;
        })
      )
      .subscribe();
  }
}
