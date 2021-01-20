import { HttpClientModule } from '@angular/common/http';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/app/material.module';
import { of } from 'rxjs';

import { CountriesComponent } from './countries.component';
import { CountriesService } from 'src/app/services/countries.service';
import { CountryBasic } from 'src/app/models/country-basic.model';
import { By } from '@angular/platform-browser';

describe('CountriesComponent', () => {
  let component: CountriesComponent;
  let fixture: ComponentFixture<CountriesComponent>;
  let mockCountriesService;

  beforeEach(async(() => {
    mockCountriesService = jasmine.createSpyObj(['getCountries']);
    mockCountriesService.getCountries.and.returnValue(of([]));

    TestBed.configureTestingModule({
      imports: [ BrowserAnimationsModule, HttpClientModule, MaterialModule ],
      declarations: [ CountriesComponent ],
      providers: [
        { provide: CountriesService, useValue: mockCountriesService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it(`should retrieve countries from the API`, () => {
    fixture.detectChanges();

    // Assert:
    expect(mockCountriesService.getCountries).toHaveBeenCalled();
  });

  it(`should load retrieved countries into the page`, () => {
    // Arrange:
    const countries = getCountries();
    mockCountriesService.getCountries.and.returnValue(of(countries));

    component.ngOnInit();

    // Act:
    fixture.detectChanges();

    // Assert:
    const countriesTableEl = fixture.debugElement.query(By.css('.mat-elevation-z8 .mat-table')).nativeElement;
    expect(countriesTableEl.textContent).toContain('CountryX');
    expect(countriesTableEl.textContent).toContain('CountryY');
  });
});

function getCountries(): CountryBasic[] {
  console.log("called getCountry");
  return [
    {
      name: "CountryX",
      flag: "FlagX"
    },
    {
      name: "CountryY",
      flag: "FlagY"
    }    
  ];
}