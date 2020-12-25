import { AfterViewInit, Component, ViewChild, OnInit } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { CountryService } from "src/app/services";
import { Country } from "src/app/models/country";
import { UntilDestroy, untilDestroyed } from "@ngneat/until-destroy";
import { Router } from "@angular/router";

@UntilDestroy()
@Component({
  selector: "app-country-list",
  templateUrl: "./country-list.component.html",
  styleUrls: ["./country-list.component.scss"],
})
export class CountryListComponent implements OnInit {
  dataSource: any;
  countries: Country[];
  loading: boolean = true;
  displayedColumns: string[] = ["flag", "name"];

  @ViewChild(MatPaginator, { static: false }) set matPaginator(
    paginator: MatPaginator
  ) {
    if (this.dataSource) {
      this.dataSource.paginator = paginator;
    }
  }

  constructor(private countryService: CountryService, private router: Router) {}

  ngOnInit() {
    this.countryService
      .GetAllCountries()
      .pipe(untilDestroyed(this))
      .subscribe((data) => {
        this.dataSource = new MatTableDataSource<Country>(data);
        this.countries = data;
        this.loading = false;
      });
  }

  selectRowRecord(selectedRow: any) {
    //get countries' name from alpha3Code
    let borderingCountries = selectedRow.borders.map((border) => {
      return this.countries.find((country) => {
        return country.alpha3Code == border;
      }).name;
    });

    //restructuring
    selectedRow.borderingCountries = borderingCountries;

    this.countryService.setSelectedCountry(selectedRow);

    this.router.navigateByUrl("/country-detail");
  }
}
