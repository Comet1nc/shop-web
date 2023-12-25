import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PaymentComponent implements OnInit {
  constructor(
    private auth: AuthService,
    private router: Router,
    private products: ProductsService
  ) {}
  ngOnInit(): void {
    if (!this.auth.currentUserId) return;

    this.products
      .removeAllProductsFromUser(this.auth.currentUserId)
      .subscribe((e) => {});
  }
}
