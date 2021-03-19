import {Component, OnDestroy, OnInit} from '@angular/core';
import {CountriesService} from '../services';
import {Country} from '../services/models/country';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

@Component({
  selector: 'app-country-listing',
  templateUrl: './country-listing.component.html',
  styleUrls: ['./country-listing.component.scss']
})
export class CountryListingComponent implements OnInit, OnDestroy {

  destroy$ = new Subject<boolean>();
  totalListOfCountries: Country[];
  listOfCountries: Country[];
  loading = false;

  constructor(private countriesService: CountriesService) {
  }

  ngOnInit() {
    this.fetchAllCountries();
    this.loading = true;
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  fetchAllCountries(): void {
    this.countriesService.getAllCountries().pipe(takeUntil(this.destroy$)).subscribe(listOfCountries => {
      this.totalListOfCountries = listOfCountries;
      this.listOfCountries = this.pageThroughCountries(0, 10);
      this.loading = false;
    });
  }

  showCountryFullDetails(countryName: string): void {
    console.log(countryName);
  }

  pageThroughCountries(from: number, to: number): Country[] {
    return this.totalListOfCountries.slice(from, to);
  }

  pageChangeHandler($event): void {
    const from = $event.pageIndex * $event.pageSize;
    const to = from + $event.pageSize;
    this.listOfCountries = this.pageThroughCountries(from, to);
  }

}
