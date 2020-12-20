import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CountryComponent } from './country.component';
import { CountryDetailComponent } from './country-detail/country-detail.component';

const routes: Routes = [{ path: '', component: CountryComponent },
{ path: 'country/:id', component: CountryDetailComponent },];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CountryRoutingModule { }
