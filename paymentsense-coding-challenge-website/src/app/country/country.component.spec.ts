import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryService } from 'src/app/services';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material';
import { of } from 'rxjs';
import { CountryComponent } from './country.component';

describe('CountryComponent', () => {
  let component: CountryComponent;
  let fixture: ComponentFixture<CountryComponent>;
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
        CountryComponent,CountryComponent 
      ],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
      providers: [
        { provide: CountryService, useValue: mockCountryServices  }
      ]})
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
