import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "src/app/shared/shared.module";
import { CountriesItemComponent } from "./components/countries-item/countries-item.component";
import { CountriesListComponent } from "./components/countries-list/countries-list.component";
import { CountryInformationComponent } from "./components/country-information/country-information.component";
import { CountriesPaginationComponent } from "./containers/countries-pagination/countries-pagination.component";
import { CountriesComponent } from "./containers/countries/countries.component";
import { CountriesRoutingModule } from "./countries-routing.module";
import { CountryComponent } from "./pages/country/country.component";

@NgModule({
  declarations: [
    CountryComponent,
    CountriesComponent,
    CountriesListComponent,
    CountriesItemComponent,
    CountryInformationComponent,
    CountriesPaginationComponent,
  ],
  imports: [CommonModule, CountriesRoutingModule, SharedModule],
  providers: [],
  exports: [],
})
export class CountriesModule {}
