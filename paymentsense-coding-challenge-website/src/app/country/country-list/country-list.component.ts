import { AfterViewInit, Component, ViewChild, OnInit } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { CountryService } from "src/app/services";
import { Country } from "src/app/models/country";

@Component({
  selector: "app-country-list",
  templateUrl: "./country-list.component.html",
  styleUrls: ["./country-list.component.scss"],
})
export class CountryListComponent implements OnInit {
  countries: any;
  loading: boolean = true;
  paginator: any;

  @ViewChild(MatPaginator, { static: false }) set matPaginator(
    paginator: MatPaginator
  ) {
    if (this.countries) {
      this.countries.paginator = paginator;
    }
  }
  displayedColumns: string[] = ["flag", "name"];

  constructor(private countryService: CountryService) {}

  ngOnInit() {
    this.countryService.GetAllCountries().subscribe((data) => {
      this.countries = new MatTableDataSource<Country>(data);
      this.loading = false;
    });
  }
}

