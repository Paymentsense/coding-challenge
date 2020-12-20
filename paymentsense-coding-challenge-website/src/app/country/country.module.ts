import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CountryRoutingModule } from './country-routing.module';
import { CountryComponent } from './country.component';
import { CountryDetailComponent } from './country-detail/country-detail.component';


@NgModule({
  declarations: [CountryComponent,CountryDetailComponent],
  imports: [
    CommonModule,
    CountryRoutingModule
  ]
})
export class CountryModule { }
