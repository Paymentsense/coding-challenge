import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { CountryForPagination } from "src/app/core/api-clients";

@Component({
  selector: "app-countries-item",
  templateUrl: "./countries-item.component.html",
  styleUrls: ["./countries-item.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountriesItemComponent {
  @Input() country: CountryForPagination;
}
