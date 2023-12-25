import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Product } from 'src/app/shared/models/product.model';
import { ProductsService } from '../products.service';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.css'],
})
export class RecordsComponent implements OnInit, OnDestroy {
  userProducts: Product[] = [];

  constructor(
    private productsService: ProductsService,
    public auth: AuthService,
    private snackbar: MatSnackBar
  ) {}

  ngOnDestroy(): void {}

  ngOnInit(): void {
    this.getAllUserProducts();
  }

  getAllPrice() {
    let price = 0;
    for (let product of this.userProducts) {
      price += +product.price * product.cartCount;
    }
    return price;
  }

  getAllUserProducts() {
    if (!this.auth.currentUserId) {
      this.snackbar.open('Войдите в систему');
      return;
    }

    this.productsService.getAllUserProducts(this.auth.currentUserId).subscribe({
      next: (r) => {
        this.userProducts = r;
        console.log(this.userProducts);
      },
      error: (e) => {
        this.snackbar.open('Корзина пуста');
      },
    });
  }

  deleteFromCart(product: Product) {
    if (!this.auth.currentUserId) return;
    this.productsService
      .deleteProductFromUser(this.auth.currentUserId, product.id)
      .subscribe({
        next: (r) => {
          this.snackbar.open('Успешно удалено.');
          this.getAllUserProducts();
        },
        error: (e) => {
          this.snackbar.open('Ошибка удаления');
        },
      });
  }

  deacrese(product: Product) {
    if (2 > product.cartCount) return;
    product.cartCount--;
  }

  increase(product: Product) {
    if (product.count < product.cartCount + 1) {
      this.snackbar.open('Достигнуто максимальное число товаров', undefined, {
        duration: 1000,
      });
      return;
    }
    product.cartCount++;
  }
}
