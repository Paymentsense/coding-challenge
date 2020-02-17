import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }    from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { PaymentsenseGeographyService } from './geography/services/paymentsense-geography.service';
import { LstCountryComponent } from './geography/geography-countrylist.component';
import { ModalComponent } from './modals/modal.component';
import { ModalService } from './modals/modal.service';

@NgModule({
  declarations: [
    AppComponent,
    LstCountryComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    NgxDatatableModule,
    FormsModule
  ],
  providers: [PaymentsenseCodingChallengeApiService,PaymentsenseGeographyService,ModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
