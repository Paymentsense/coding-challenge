import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Country} from './models/country';

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
}
