import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecordsComponent } from './records/records.component';
import { ProductsComponent } from './products/products.component';
import { PaymentComponent } from './payment/payment.component';

const routes: Routes = [
  { path: 'products', component: ProductsComponent },
  { path: 'records', component: RecordsComponent },
  { path: 'payment', component: PaymentComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SystemRoutingModule {}
