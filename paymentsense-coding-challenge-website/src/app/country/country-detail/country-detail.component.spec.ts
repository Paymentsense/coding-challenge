import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CountryDetailComponent } from "./country-detail.component";
import { CountryService } from "src/app/services";
import { CountryComponent } from "../country.component";
import { CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { RouterModule } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { filter } from "rxjs/operators";

describe("CountryDetailComponent", () => {
  let component: CountryDetailComponent;
  let fixture: ComponentFixture<CountryDetailComponent>;
  let selectedCountry: any;

  const subjectMock = new BehaviorSubject(selectedCountry);
  const mockSelectedCountryServices = {
    currentCountry: subjectMock.asObservable(),
  };

  beforeEach(async(() => {

    subjectMock
      .pipe(filter((res) => !!res))
      .subscribe((res) => expect(res).toEqual("test"));

    subjectMock.next("test");

    TestBed.configureTestingModule({
      imports: [RouterModule.forRoot([])],
      declarations: [CountryDetailComponent, CountryComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
      providers: [
        { provide: CountryService, useValue: mockSelectedCountryServices },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });

  it(`should have as title 'Country Details'`, () => {
    const fixture = TestBed.createComponent(CountryDetailComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.selectedCountry).toEqual(undefined);
  });

  it("should render title in a h2 tag", () => {
    const fixture = TestBed.createComponent(CountryDetailComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector("h2").textContent).toContain(
      "Country Details"
    );
  });
});
