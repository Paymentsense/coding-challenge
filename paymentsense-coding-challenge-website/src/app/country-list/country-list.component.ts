import { CountryDataProviderService } from "./../services/country-data-provider.service";
import { Component, OnInit, ViewChild } from "@angular/core";
import { Country } from "../models/country";
import { Subject } from "rxjs";
import { takeUntil, tap, catchError, finalize } from "rxjs/operators";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";

@Component({
  selector: "country-list",
  templateUrl: "./country-list.component.html",
  styleUrls: ["./country-list.component.scss"],
})
export class CountryListComponent implements OnInit {
  public countryList: any;
  public columnsToDisplay: string[] = ["flag", "name"];
  public loading = false;
  private unsubscribe$ = new Subject<boolean>();
  @ViewChild(MatPaginator, { static: false }) set matPaginator(
    paginator: MatPaginator
  ) {
    if (this.countryList) {
      this.countryList.paginator = paginator;
    }
  }

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
          this.countryList = new MatTableDataSource<Country>(data);
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
