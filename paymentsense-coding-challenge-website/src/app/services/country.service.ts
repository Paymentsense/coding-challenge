import { Injectable } from '@angular/core';
import { Country } from '../models/country';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private httpClient: HttpClient) { }

  public GetAllCountries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>('https://localhost:44341/country/all');
  }
}
