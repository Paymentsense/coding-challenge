import { ChangeDetectionStrategy, Component, OnInit } from "@angular/core";
import { faThumbsDown, faThumbsUp } from "@fortawesome/free-regular-svg-icons";
import { take } from "rxjs/operators";
import { PaymentsenseCodingChallengeApiFacade } from "./services";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit {
  public faThumbsUp = faThumbsUp;
  public faThumbsDown = faThumbsDown;

  public title = "Paymentsense Coding Challenge!";

  public paymentsenseCodingChallengeApiIsActive = false;
  public paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
  public paymentsenseCodingChallengeApiActiveIconColour = "red";

  constructor(
    private readonly paymentsenseCodingChallengeApiService: PaymentsenseCodingChallengeApiFacade
  ) {}

  ngOnInit() {
    this.paymentsenseCodingChallengeApiService
      .getHealth()
      .pipe(take(1))
      .subscribe(
        (apiHealth) => this.healthCheckCompleted(apiHealth),
        (_) => this.healthCheckErrored()
      );
  }

  private healthCheckCompleted(apiHealth: string) {
    {
      this.paymentsenseCodingChallengeApiIsActive = apiHealth === "Healthy";
      this.paymentsenseCodingChallengeApiActiveIcon = this
        .paymentsenseCodingChallengeApiIsActive
        ? this.faThumbsUp
        : this.faThumbsUp;
      this.paymentsenseCodingChallengeApiActiveIconColour = this
        .paymentsenseCodingChallengeApiIsActive
        ? "green"
        : "red";
    }
  }

  private healthCheckErrored() {
    {
      this.paymentsenseCodingChallengeApiIsActive = false;
      this.paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
      this.paymentsenseCodingChallengeApiActiveIconColour = "red";
    }
  }
}
