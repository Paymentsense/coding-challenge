import { Paginator } from "primeng/paginator";
import { of } from "rxjs";
import { Shallow } from "shallow-render";
import { PAGINATION_META } from "src/app/testing/pagination-response.test-data";
import { CountriesModule } from "../../countries.module";
import { CountriesFacade } from "../../facades/countries.facade";
import { CountriesPaginationService } from "../../services/countries-pagination.service";
import { CountriesPaginationComponent } from "./countries-pagination.component";

describe("CountriesPaginationComponent", () => {
  let shallow: Shallow<CountriesPaginationComponent>;

  beforeEach(() => {
    shallow = new Shallow(CountriesPaginationComponent, CountriesModule)
      .mock(CountriesFacade, { paginationMeta$: of(PAGINATION_META) })
      .mock(CountriesPaginationService, { goToPage: () => undefined });
  });

  it("should pass props in pagination component", async () => {
    const { findComponent } = await shallow.render();

    const paginator = findComponent(Paginator);

    expect(paginator.rows).toEqual(10);
    expect(paginator.totalRecords).toEqual(25);
    expect(paginator.showJumpToPageDropdown).toEqual(true);
  });

  it("should call goToPage when onPageChange event is raised", async () => {
    const { inject, find } = await shallow.render();

    const service = inject(CountriesPaginationService);

    find("p-paginator").triggerEventHandler("onPageChange", { page: 2 });

    expect(service.goToPage).toHaveBeenCalledWith(2);
  });
});
