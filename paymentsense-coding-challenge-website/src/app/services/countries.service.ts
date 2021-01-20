import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Country } from '../models/country.model';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {
  constructor(private httpClient: HttpClient) {}

  public getCountries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(`${environment.apiUrl}/api/${environment.apiVersion}/countries`);
  }

  public getCountryInfo(countryName: string): Observable<Country> {
    return this.httpClient.get<Country>(`${environment.apiUrl}/api/${environment.apiVersion}/countries/${countryName}`);
  }
}
