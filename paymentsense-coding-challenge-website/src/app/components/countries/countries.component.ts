import {ViewChild,  Component, OnInit } from '@angular/core';
import { CountryBasic } from 'src/app/models/country-basic.model';

import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CountryInfoDialogComponent } from '../country-info-dialog/country-info-dialog.component';
import { CountriesService } from 'src/app/services/countries.service';
import { first } from 'rxjs/operators';
import { Country } from 'src/app/models/country.model';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})
export class CountriesComponent implements OnInit {
  displayedColumns: string[] = ['name', 'flag'];
  dataSource: MatTableDataSource<CountryBasic>;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(
    private countryService: CountriesService,
    public dialog: MatDialog) {
    this.dataSource = new MatTableDataSource<CountryBasic>([]);
  }

  ngOnInit(): void {
    this.countryService.getCountries().pipe(first()).subscribe(
      (data: Country[]) => {
        this.dataSource = new MatTableDataSource<CountryBasic>(data);
        this.dataSource.paginator = this.paginator;
      });
  }

  dialogRef: MatDialogRef<CountryInfoDialogComponent, any>;
  getRecord(row) : void {
    if(this.dialogRef) {
      return;
    }

    this.dialogRef = this.dialog.open(CountryInfoDialogComponent, {
      width: '500px',
      maxHeight: '700px',
      data: { name: row.name, flag: row.flag }
    });

    this.dialogRef.afterClosed().subscribe(result => {
      this.dialogRef = null;
    });
  }
}