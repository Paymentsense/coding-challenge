import { NgModule } from "@angular/core";
import { CardModule } from "primeng/card";
import { DropdownModule } from "primeng/dropdown";
import { PaginatorModule } from "primeng/paginator";
import { ProgressSpinnerModule } from "primeng/progressspinner";

const modules = [
  CardModule,
  DropdownModule,
  PaginatorModule,
  ProgressSpinnerModule,
];

@NgModule({
  imports: [...modules],
  exports: [...modules],
})
export class PrimeNgModule {}
