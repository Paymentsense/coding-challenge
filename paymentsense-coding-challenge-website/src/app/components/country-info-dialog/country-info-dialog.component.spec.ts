import { HttpClientModule } from '@angular/common/http';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { of } from 'rxjs';

import { MaterialModule } from 'src/app/material.module';
import { Country } from 'src/app/models/country.model';
import { CountriesService } from 'src/app/services/countries.service';

import { CountryInfoDialogComponent } from './country-info-dialog.component';

describe('CountryInfoDialogComponent', () => {
  let component: CountryInfoDialogComponent;
  let fixture: ComponentFixture<CountryInfoDialogComponent>;
  let mockCountriesService;

  beforeEach(async(() => {
    mockCountriesService = jasmine.createSpyObj(['getCountryInfo']);
    mockCountriesService.getCountryInfo.and.returnValue(of({}));

    TestBed.configureTestingModule({
      imports: [ BrowserAnimationsModule, HttpClientModule, MaterialModule ],
      declarations: [ CountryInfoDialogComponent ],
      providers: [
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: CountriesService, useValue: mockCountriesService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryInfoDialogComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it(`should retrieve country info from the API`, () => {
    fixture.detectChanges();

    // Assert:
    expect(mockCountriesService.getCountryInfo).toHaveBeenCalled();
  });

  it(`should load retrieved questions into the page variable`, () => {
    // Arrange:
    const country = getCountry();
    mockCountriesService.getCountryInfo.and.returnValue(of(country));

    // Act:
    fixture.detectChanges();

    // Assert:
    expect(component.country).toBe(country);
  });
});

function getCountry(): Country {
  return {
      name: "CountryX",
      flag: "FlagX",
      capital: "CapitalX",
      population: 1,
      borders: ["Border1", "Border2"],
      currencies: [ {code: "Currency1"}, {code: "Currency2"} ],
      languages: [ {name: "Language1"}, {name: "Language2"} ],
      timeZones: ["TimeZone1", "TimeZone2"]
    };
}