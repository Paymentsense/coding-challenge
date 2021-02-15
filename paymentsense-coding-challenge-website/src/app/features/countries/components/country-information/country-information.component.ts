import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { Country } from "src/app/core/api-clients";

@Component({
  selector: "app-country-information",
  templateUrl: "./country-information.component.html",
  styleUrls: ["./country-information.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryInformationComponent {
  @Input() country: Country;

  options: any;

  ngOnInit() {
    this.options = {
      center: { lat: 36.890257, lng: 30.707417 },
      zoom: 12,
    };
  }
}
