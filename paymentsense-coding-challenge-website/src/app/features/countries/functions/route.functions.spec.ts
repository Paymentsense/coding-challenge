import { ActivatedRouteSnapshot } from "@angular/router";
import { getPageTakeFromParams } from "./route.functions";

describe("getPageTakeFromParams", () => {
  it("should return page take from Params", () => {
    const routeSnapshot: Partial<ActivatedRouteSnapshot> = {
      queryParams: { page: 2, take: 20 },
    };

    const { page, take } = getPageTakeFromParams(
      routeSnapshot as ActivatedRouteSnapshot
    );

    expect(page).toBe(2);
    expect(take).toBe(20);
  });

  it("should return default page take when params don't exist", () => {
    const routeSnapshot: Partial<ActivatedRouteSnapshot> = {
      queryParams: {},
    };

    const { page, take } = getPageTakeFromParams(
      routeSnapshot as ActivatedRouteSnapshot
    );

    expect(page).toBe(1);
    expect(take).toBe(10);
  });
});
