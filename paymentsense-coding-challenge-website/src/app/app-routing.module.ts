import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {CountryListingComponent} from './countries/country-listing.component';

const routes: Routes = [{
  path: '',
  component: CountryListingComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
