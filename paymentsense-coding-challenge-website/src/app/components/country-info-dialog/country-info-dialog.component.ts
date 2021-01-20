import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { first } from 'rxjs/operators';
import { CountryBasic } from 'src/app/models/country-basic.model';
import { Country } from 'src/app/models/country.model';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-country-info-dialog',
  templateUrl: './country-info-dialog.component.html',
  styleUrls: ['./country-info-dialog.component.scss']
})
export class CountryInfoDialogComponent implements OnInit {
  public country: Country;

  constructor(
    private countryService: CountriesService,
    public dialogRef: MatDialogRef<CountryInfoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CountryBasic) {
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    this.countryService.getCountryInfo(this.data.name).pipe(first()).subscribe(
        (val: Country) => {
          this.country = val;
        });
  }

  getUrl()
  {    
    return "url(" + this.data.flag + ")";
  }  
}
