import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CountriesComponent } from './components/countries/countries.component';
import { MaterialModule } from './material.module';
import { CountryInfoDialogComponent } from './components/country-info-dialog/country-info-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    CountriesComponent,
    CountryInfoDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    MaterialModule
  ],
  providers: [PaymentsenseCodingChallengeApiService],
  bootstrap: [AppComponent],
  entryComponents: [
    CountryInfoDialogComponent
  ]
})
export class AppModule { }
