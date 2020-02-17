export class Country{
    public name:string;
    public topLevelDomain:string[];
    public alpha2Code:string;
    public alpha3Code:string;
    public callingCodes:string[];
    public capital:string;
    public altSpellings:string[];
    public region:string;
    public subregion:string;
    public population?:number;
    public latlng?:number[];
    public demonym:string;
    public area?:number[];
    public gini?:number[];
    public timezones:string[];
    public borders:string[];
    public nativeName:string;
    public numericCode:string;
    public currencies:Currency[];
    public languages:Language[];
    public translations:Translations;
    public flag:string;
    public regionalBlocs:RegionalBloc[];
    public cioc:string;
        
}

export class Currency {
    public code:string;
    public name:string;
    public symbol:string;
}

export class Language {
    public iso639_1:string;
    public iso639_2:string;
    public name:string;
    public nativeName:string;
}

export class RegionalBloc {
    public acronym:string;
    public name:string;
    public otherAcronyms:any[];
    public otherNames:string[];
}
export class Translations {
    public de:string;
    public fr:string;
    public ja:string;
    public it:string;
    public br:string;
    public pt:string;
}

export class Page {
    //The number of elements in the page
    size: number = 0;
    //The total number of elements
    totalElements: number = 0;
    //The total number of pages
    totalPages: number = 0;
    //The current page number
    pageNumber: number = 0;
  }