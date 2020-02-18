import { Component,OnInit  } from '@angular/core';
import { take } from 'rxjs/operators';
import { Router, ActivatedRoute } from "@angular/router";
import { faThumbsUp, faThumbsDown } from '@fortawesome/free-regular-svg-icons';
import { PaymentsenseGeographyService } from './services/paymentsense-geography.service';
import { Country } from './models/paymentsense-geography.model';
import { ModalService } from '../modals/modal.service';


@Component({
  selector: 'country-list',
  templateUrl: './geography-countrylist.component.html'
})
export class LstCountryComponent implements OnInit {
    public isFetchingData:boolean=false;
    public countries:Country[]=[];
    public country:Country=new Country();
    constructor(private geographyservice:PaymentsenseGeographyService,private modalService: ModalService) {
        
      }

      ngOnInit() {
        this.getCountries();
      }
      private getCountries():void{
        this.isFetchingData=true;
        this.geographyservice.getCountries().pipe(take(1))
        .subscribe(
          result => {
            this.countries=result;
            this.isFetchingData=false;
          },
          _ => {
            this.isFetchingData=false;
          });
      }

    openModal(id: string,row:Country) {
      if(row){
        this.country=row;
        this.modalService.open(id);
      }
        
    }

    closeModal(id: string) {
        this.modalService.close(id);
    }
}
