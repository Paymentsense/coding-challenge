import {Injectable} from '@angular/core';
import {Country} from './models/country';
import {CountriesService} from './countries.service';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private countriesService: CountriesService, private router: Router) {
  }

  searchByCountry(searchTerm: string): void {
    this.countriesService.searchForCountry(searchTerm)
      .subscribe((searchResult: Country) => {
        if (searchResult) {
          this.goToResults(searchResult);
        } else {
          this.goToNoResultsFound();
        }
      });
  }

  goToResults(result: Country): void {
    const countryName = result ? result.name : null;
    this.router.navigate([`/country/${countryName}`]);
  }

  goToNoResultsFound(): void {
    this.router.navigate(['/noresults']);
  }

}
