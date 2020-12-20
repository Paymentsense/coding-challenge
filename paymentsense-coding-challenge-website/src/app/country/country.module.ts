import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table';

import { CountryRoutingModule } from './country-routing.module';
import { CountryComponent } from './country.component';
import { CountryDetailComponent } from './country-detail/country-detail.component';
import { CountryListComponent } from './country-list/country-list.component';
import {MatPaginatorModule} from '@angular/material/paginator';


@NgModule({
  declarations: [CountryComponent,CountryDetailComponent,CountryListComponent],
  imports: [
    CommonModule,
    CountryRoutingModule,
    MatTableModule,
    MatPaginatorModule,
  ],
})
export class CountryModule { }
