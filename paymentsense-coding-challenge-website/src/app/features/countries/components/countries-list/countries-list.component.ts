import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { CountryForPagination } from "src/app/core/api-clients";

@Component({
  selector: "app-countries-list",
  templateUrl: "./countries-list.component.html",
  styleUrls: ["./countries-list.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountriesListComponent {
  @Input() countries: CountryForPagination[];
}
