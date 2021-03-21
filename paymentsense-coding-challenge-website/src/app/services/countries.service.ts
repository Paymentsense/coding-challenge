import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Country} from './models/country';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  baseUrl = environment.baseAPIUrl;

  constructor(private httpClient: HttpClient) {
  }

  getAllCountries(): Observable<Country[]> {
    const getAllCountriesUrl = `${this.baseUrl}/rest/v2/all`;
    return this.httpClient.get<Country[]>(getAllCountriesUrl);
  }

  filterCountryByName(countryName: string): Observable<Country> {
    const getCountryDetailsByNameUrl = `${this.baseUrl}/rest/v2/name/${countryName}`;
    return this.httpClient.get<Country[]>(getCountryDetailsByNameUrl).pipe(
      map(countries => countries.find(country => country.name === countryName)
      )
    );
  }

  searchForCountry(searchTerm: string) {
    return this.filterCountryByName(searchTerm);
  }
}
