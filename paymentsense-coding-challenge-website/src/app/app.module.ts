import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {CountryListingComponent} from './countries/country-listing.component';
import {MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatListModule, MatPaginatorModule} from '@angular/material';
import { CountryDetailsComponent } from './country/country-details.component';
import { LoaderComponent } from './shared/loader.component';
import { NavBarComponent } from './shared/nav-bar.component';
import {ReactiveFormsModule} from '@angular/forms';
import { ResultsNotFoundComponent } from './results-not-found/results-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    CountryListingComponent,
    CountryDetailsComponent,
    LoaderComponent,
    NavBarComponent,
    ResultsNotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    MatListModule,
    MatPaginatorModule,
    MatCardModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  providers: [PaymentsenseCodingChallengeApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
