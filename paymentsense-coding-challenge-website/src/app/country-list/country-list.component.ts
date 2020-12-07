import { CountryDataProviderService } from "./../services/country-data-provider.service";
import { Component, OnInit, ViewChild } from "@angular/core";
import { Country } from "../models/country";
import { Subject } from "rxjs";
import { takeUntil, tap, catchError, finalize } from "rxjs/operators";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import {
  animate,
  state,
  style,
  transition,
  trigger,
} from "@angular/animations";
import { Currency } from "../models/currency";
import { Language } from "../models/language";

@Component({
  selector: "country-list",
  templateUrl: "./country-list.component.html",
  styleUrls: ["./country-list.component.scss"],
  animations: [
    trigger("detailExpand", [
      state("collapsed", style({ height: "0px", minHeight: "0" })),
      state("expanded", style({ height: "*" })),
      transition(
        "expanded <=> collapsed",
        animate("225ms cubic-bezier(0.4, 0.0, 0.2, 1)")
      ),
    ]),
  ],
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
  expandedElement: Country | null;

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

  getCurrencies(currencies: Currency[]): string {
    return currencies.map((c) => c.name).join(",");
  }

  getLanguages(languages: Language[]): string {
    return languages.map((l) => l.name).join(",");
  }
}
