import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CountriesComponent } from "./containers/countries/countries.component";
import { CountryComponent } from "./pages/country/country.component";
import { CountriesResolver } from "./resolvers/countries.resolver";
import { CountryResolver } from "./resolvers/country.resolver";

const routes: Routes = [
  {
    path: "",
    component: CountriesComponent,
    resolve: { countries: CountriesResolver },
    runGuardsAndResolvers: "paramsOrQueryParamsChange",
  },
  {
    path: "country",
    redirectTo: "",
  },
  {
    path: "country/:code",
    component: CountryComponent,
    resolve: { country: CountryResolver },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CountriesRoutingModule {}
