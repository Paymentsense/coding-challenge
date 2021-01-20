import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CountriesComponent } from './components/countries/countries.component';

const routes: Routes = [
    { 
        path: '',
        component: CountriesComponent
    },
    {
        path: '**',
        redirectTo: '' 
    }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
