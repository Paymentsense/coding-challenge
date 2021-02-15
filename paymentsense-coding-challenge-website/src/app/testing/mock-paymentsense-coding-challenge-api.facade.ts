import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MockPaymentsenseCodingChallengeApiFacade {
  public getHealth(): Observable<string> {
    return of('Healthy');
  }
}
