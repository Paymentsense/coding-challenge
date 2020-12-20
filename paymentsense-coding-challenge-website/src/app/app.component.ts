import { Component } from '@angular/core';
import { PaymentsenseCodingChallengeApiService, CountryService } from './services';
import { take } from 'rxjs/operators';
import { faThumbsUp, faThumbsDown } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public faThumbsUp = faThumbsUp;
  public faThumbsDown = faThumbsDown;
  public title = 'Paymentsense Coding Challenge!';
  public paymentsenseCodingChallengeApiIsActive = false;
  public paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
  public paymentsenseCodingChallengeApiActiveIconColour = 'red';

  constructor() {
  }
}
