import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CountryService } from 'src/app/services';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.scss']
})
export class CountryDetailComponent implements OnInit {

  alpha3Code:string;
  selectedCountry:any;
  constructor( private countryService: CountryService,   private route: ActivatedRoute,) { 

    this.alpha3Code = route.snapshot.params.id;

  }

  ngOnInit() {
    this.getSelectedCountry();
  }
  getSelectedCountry() {
    this.countryService.GetAllCountries().subscribe((data) => {
    });
  }

}
