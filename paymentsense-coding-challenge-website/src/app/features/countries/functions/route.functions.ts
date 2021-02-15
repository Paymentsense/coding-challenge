import { ActivatedRouteSnapshot } from "@angular/router";
import { environment } from "src/environments/environment";

export function getPageTakeFromParams(routeSnapshot: ActivatedRouteSnapshot) {
  return {
    page: !!routeSnapshot.queryParams.page
      ? parseInt(routeSnapshot.queryParams.page)
      : 1,
    take: !!routeSnapshot.queryParams.take
      ? parseInt(routeSnapshot.queryParams.take)
      : environment.pageSize,
  };
}
