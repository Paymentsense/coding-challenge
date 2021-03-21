import {Component, Input, OnDestroy} from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import {SearchService} from '../services';
import {Subject} from 'rxjs';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnDestroy {

  @Input() title: string;
  searchTerm = new FormControl('', Validators.required);
  destroy$ = new Subject<boolean>();

  constructor(private searchService: SearchService) {
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  searchHandler(): void {
    if (this.searchTerm.value) {
     this.searchService.searchByCountry(this.searchTerm.value);
    }
  }

}
