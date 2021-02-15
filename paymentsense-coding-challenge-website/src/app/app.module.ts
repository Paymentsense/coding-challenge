import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { environment } from "src/environments/environment";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { API_BASE_URL } from "./core/api-clients";
import { NotFoundComponent } from "./pages/not-found/not-found.component";
import { PaymentsenseCodingChallengeApiFacade } from "./services";

@NgModule({
  declarations: [AppComponent, NotFoundComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
  ],
  providers: [
    PaymentsenseCodingChallengeApiFacade,
    { provide: API_BASE_URL, useValue: environment.baseUrl },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
