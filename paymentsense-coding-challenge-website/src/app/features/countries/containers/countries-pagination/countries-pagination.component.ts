import { ChangeDetectionStrategy, Component } from "@angular/core";
import { CountriesFacade } from "../../facades/countries.facade";
import { CountriesPaginationService } from "../../services/countries-pagination.service";

@Component({
  selector: "app-countries-pagination",
  templateUrl: "./countries-pagination.component.html",
  styleUrls: ["./countries-pagination.component.scss"],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountriesPaginationComponent {
  paginationMeta$ = this.countriesFacade.paginationMeta$;

  constructor(
    private readonly countriesFacade: CountriesFacade,
    private readonly countriesPaginationService: CountriesPaginationService
  ) {}

  paginate(event) {
    this.countriesPaginationService.goToPage(event.page);
  }
}
