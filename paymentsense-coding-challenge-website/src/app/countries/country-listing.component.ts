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
  listOfCountries: Country[];

  constructor(private countriesService: CountriesService) {
  }

  ngOnInit() {
    this.fetchAllCountries();
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  fetchAllCountries(): void {
    this.countriesService.getAllCountries().pipe(takeUntil(this.destroy$)).subscribe(listOfCountries => {
      this.listOfCountries = listOfCountries;
    });
  }

}
