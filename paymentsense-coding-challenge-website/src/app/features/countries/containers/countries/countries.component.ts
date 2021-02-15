import { ChangeDetectionStrategy, Component } from "@angular/core";
import { CountriesFacade } from "../../facades/countries.facade";

@Component({
  selector: "app-countries",
  templateUrl: "./countries.component.html",
  styleUrls: ["./countries.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountriesComponent {
  countries$ = this.countriesFacade.countries$;

  constructor(private readonly countriesFacade: CountriesFacade) {}
}
