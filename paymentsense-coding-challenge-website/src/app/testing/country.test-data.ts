import { Country } from "../core/api-clients";

export const COUNTRY: Country = {
  name: "Test Country 1",
  flag: "https://www.flags.net/testflag.png",
  capital: "Test Capital",
  languages: [{ name: "Test Language 1" }, { name: "Test Language 2" }],
  population: 100,
  timezones: ["UTC-04:00"],
  currencies: [{ name: "East Caribbean dollar", symbol: "$" }],
  borders: ["TestBorder"],
};
