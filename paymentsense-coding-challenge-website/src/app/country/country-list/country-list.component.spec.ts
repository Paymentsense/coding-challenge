import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryService } from 'src/app/services';
import { CountryComponent } from '../country.component';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CountryListComponent } from './country-list.component';
import { MatTableModule } from '@angular/material';
import { of } from 'rxjs';

describe('CountryListComponent', () => {
  let component: CountryListComponent;
  let fixture: ComponentFixture<CountryListComponent>;
  let mockCountryServices;

  beforeEach(async(() => {
    mockCountryServices = jasmine.createSpyObj(['GetAllCountries']);
    mockCountryServices.GetAllCountries.and.returnValue(of(null));

    TestBed.configureTestingModule({
      imports: [
        RouterModule.forRoot([]),
        MatTableModule,
      ],
      declarations: [
        CountryListComponent,CountryComponent 
      ],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
      providers: [
        { provide: CountryService, useValue: mockCountryServices  }
      ]})
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it(`should have as title 'Countries'`, () => {
    const fixture = TestBed.createComponent(CountryListComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.loading).toEqual(true);
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(CountryListComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Countries');
  });
});
