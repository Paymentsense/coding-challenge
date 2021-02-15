import {
  CountryForPaginationResponse,
  PaginationMeta,
} from "../core/api-clients";
import { COUNTRY } from "./country.test-data";

export const PAGINATION_META: PaginationMeta = {
  page: 1,
  take: 10,
  maxPage: 3,
  totalItems: 25,
};

export const PAGINATION_RESPONSE: CountryForPaginationResponse = {
  countries: [COUNTRY],
  meta: PAGINATION_META,
};
