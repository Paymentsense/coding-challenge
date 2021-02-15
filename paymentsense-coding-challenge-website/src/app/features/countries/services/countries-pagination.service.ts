import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { getPageTakeFromParams } from "../functions/route.functions";

@Injectable({ providedIn: "root" })
export class CountriesPaginationService {
  constructor(
    private readonly route: ActivatedRoute,
    private readonly router: Router
  ) {}

  goToPage(page: number) {
    const { take } = getPageTakeFromParams(this.route.snapshot);

    this.updateQueryParams(page + 1, take);
  }

  private updateQueryParams(page: number, take: number) {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: {
        page: page,
        take: take,
      },
      queryParamsHandling: "merge",
      skipLocationChange: false,
    });
  }
}
