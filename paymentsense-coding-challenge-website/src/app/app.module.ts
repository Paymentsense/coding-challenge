import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { PaymentsenseCodingChallengeApiService } from "./services";
import { HttpClientModule } from "@angular/common/http";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { CountryListComponent } from "./country-list/country-list.component";
import { CountryDataProviderService } from "./services/country-data-provider.service";

@NgModule({
  declarations: [AppComponent, CountryListComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
  ],
  providers: [
    PaymentsenseCodingChallengeApiService,
    CountryDataProviderService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
