export interface Country {
  name: string;
  alpha2Code: string;
  alpha3Code: string;
  capital: string;
  region: string;
  subRegion: string;
  population: number;
  flag: string;
  borders: string[];
  timezones: string[];
  languages: Languages[];
  currency: Currencies[];
}

interface Languages {
  name: string;
  iso639_1?: string;
  iso639_2?: string;
}

interface Currencies {
  code: string;
  name: string;
  symbol?: string;
}
