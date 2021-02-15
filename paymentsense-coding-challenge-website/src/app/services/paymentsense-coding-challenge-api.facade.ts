import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HealthClient } from "../core/api-clients";

@Injectable({
  providedIn: "root",
})
export class PaymentsenseCodingChallengeApiFacade {
  constructor(private readonly client: HealthClient) {}

  public getHealth(): Observable<string> {
    return this.client.health_Get();
  }
}
