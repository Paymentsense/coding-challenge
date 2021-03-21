import {Component, OnDestroy, OnInit} from '@angular/core';
import {CountriesService} from '../services';
import {ActivatedRoute, Router} from '@angular/router';
import {switchMap, takeUntil} from 'rxjs/operators';
import {Observable, Subject} from 'rxjs';
import {Country} from '../services/models/country';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.scss']
})
export class CountryDetailsComponent implements OnInit, OnDestroy {
  country$ = new Observable<Country>();
  destroy$ = new Subject<boolean>();
  selectedCountryName: string;
  selectedCountry: Country;

  constructor(private countriesService: CountriesService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit() {
    this.country$ = this.route.paramMap.pipe(
      switchMap(params => {
        this.selectedCountryName = params.get('name');
        return this.countriesService.filterCountryByName(this.selectedCountryName);
      })
    );

    this.getSelectedCountryDetails();
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  getSelectedCountryDetails(): void {
    this.country$.pipe(takeUntil(this.destroy$)).subscribe(country => {
      this.selectedCountry = country;
    });
  }

  goToFullListing(): void {
    this.router.navigate(['/countries']);
  }

}
