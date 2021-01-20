import { CountryBasic } from "./country-basic.model";

export class Country extends CountryBasic {
  capital: string;
  population: number;
  languages: any[];
  currencies: any[];
  borders: string[];
  timeZones: string[];
}