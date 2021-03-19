import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {CountryListingComponent} from './countries/country-listing.component';
import {CountryDetailsComponent} from './country/country-details.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'countries',
    pathMatch: 'full'
  },
  {
    path: 'countries',
    component: CountryListingComponent
  }, {
    path: 'country/:name',
    component: CountryDetailsComponent
  },
  {
    path: '**',
    component: CountryListingComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
