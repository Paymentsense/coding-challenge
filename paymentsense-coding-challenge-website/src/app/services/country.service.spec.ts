import { CountryService } from ".";
import { of } from 'rxjs';

let httpClientSpy: { get: jasmine.Spy };
let countryService: CountryService;

beforeEach(() => {
  // TODO: spy on other methods too
  httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
  countryService = new CountryService(httpClientSpy as any);
});

it('should return expected countries (HttpClient called once)', () => {
  httpClientSpy.get.and.returnValue(of(null));

  countryService.GetAllCountries().subscribe(
    heroes => expect(heroes).toEqual(null, 'expected heroes'),
    fail
  );
  expect(httpClientSpy.get.calls.count()).toBe(1, 'one call');
});