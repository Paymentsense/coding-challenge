import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Country } from 'src/app/geography/models/paymentsense-geography.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentsenseGeographyService {
  constructor(private httpClient: HttpClient) {}

  public getCountries(): Observable<Country[]> {
    return this.httpClient.get<Country[]>('https://localhost:44352//Geographic//countries', {  });
  }
}
