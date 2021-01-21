# CodingChallenge
Paymentsense coding challenge

## Setup
* Please download latest dotnet core (3+) -> https://dotnet.microsoft.com/download/dotnet-core

## API Cors Settings
* Before you run API, please make sure to set CorsOrigin to have url of WebSite(UI Angular side) on appsetting.json file on Paymentsense.Coding.Challenge.Api project.
* Also you can also set CacheTimeInSeconds setting to defined duration of caching the countries list retrieved from restcountries.eu API.

"AppSettings": {
 "CorsOrigin": "http://localhost:4200",
 "RestCountriesUrl": "https://restcountries.eu/rest/v2",
 "CacheTimeInSeconds": 300
}