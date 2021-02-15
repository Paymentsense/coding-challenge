import { ActivatedRoute, Router } from "@angular/router";
import { Shallow } from "shallow-render";
import { CountriesModule } from "../countries.module";
import { CountriesPaginationService } from "./countries-pagination.service";
describe("CountriesPaginationService", () => {
  let shallow: Shallow<CountriesPaginationService>;

  beforeEach(() => {
    shallow = new Shallow(CountriesPaginationService, CountriesModule)
      .mock(ActivatedRoute, {
        snapshot: { queryParams: { page: 1, take: 10 } },
      })
      .mock(Router, { navigate: () => undefined });
  });

  it("should update query params when goToPage is called", () => {
    const { instance, inject } = shallow.createService();

    const route = inject(ActivatedRoute);

    const router = inject(Router);

    instance.goToPage(3);

    expect(router.navigate).toHaveBeenCalledWith([], {
      relativeTo: route,
      queryParams: {
        page: 4,
        take: 10,
      },
      queryParamsHandling: "merge",
      skipLocationChange: false,
    });
  });
});
