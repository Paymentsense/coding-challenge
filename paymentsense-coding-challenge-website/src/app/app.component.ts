import { Component,OnInit  } from '@angular/core';
import { PaymentsenseCodingChallengeApiService } from './services';
import { take } from 'rxjs/operators';
import { Router, ActivatedRoute } from "@angular/router";
import { faThumbsUp, faThumbsDown } from '@fortawesome/free-regular-svg-icons';
import { PaymentsenseGeographyService } from './geography/services/paymentsense-geography.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public faThumbsUp = faThumbsUp;
  public faThumbsDown = faThumbsDown;
  public title = 'Paymentsense Coding Challenge!';
  public paymentsenseCodingChallengeApiIsActive = false;
  public paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
  public paymentsenseCodingChallengeApiActiveIconColour = 'red';
  public showCountry:boolean=false;

  constructor(private paymentsenseCodingChallengeApiService: PaymentsenseCodingChallengeApiService,private geographyservice:PaymentsenseGeographyService,private router: Router, private route: ActivatedRoute) {
    paymentsenseCodingChallengeApiService.getHealth().pipe(take(1))
    .subscribe(
      apiHealth => {
        this.paymentsenseCodingChallengeApiIsActive = apiHealth === 'Healthy';
        this.paymentsenseCodingChallengeApiActiveIcon = this.paymentsenseCodingChallengeApiIsActive
          ? this.faThumbsUp
          : this.faThumbsUp;
        this.paymentsenseCodingChallengeApiActiveIconColour = this.paymentsenseCodingChallengeApiIsActive
          ? 'green'
          : 'red';
      },
      _ => {
        this.paymentsenseCodingChallengeApiIsActive = false;
        this.paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
        this.paymentsenseCodingChallengeApiActiveIconColour = 'red';
      });
  }
  ngOnInit() {
  }
  public showCountryClick():void
  {
    this.router.navigateByUrl('/countrylist', { relativeTo: this.route });
    this.showCountry=true;
  }
}
