import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AngularMaterialModule } from '../libs/angular-material.module';
import { SharedModule } from '../shared/shared.module';
import { SystemRoutingModule } from './system-routing.module';
import { SystemComponent } from './system.component';
import { RecordsComponent } from './records/records.component';
import { HeaderComponent } from './header/header.component';
import { ProductsComponent } from './products/products.component';
import { PaymentComponent } from './payment/payment.component';

@NgModule({
  declarations: [
    SystemComponent,
    ProductsComponent,
    RecordsComponent,
    PaymentComponent,
    HeaderComponent,
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    HttpClientModule,
    SharedModule,
    SystemRoutingModule,
  ],
  exports: [],
})
export class SystemModule {}
