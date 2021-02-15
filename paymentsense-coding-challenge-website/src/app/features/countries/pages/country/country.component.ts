import { ChangeDetectionStrategy, Component } from "@angular/core";
import { CountriesFacade } from "../../facades/countries.facade";

@Component({
  selector: "app-country",
  templateUrl: "./country.component.html",
  styleUrls: ["./country.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryComponent {
  country$ = this.countriesFacade.country$;

  constructor(private readonly countriesFacade: CountriesFacade) {}
}
