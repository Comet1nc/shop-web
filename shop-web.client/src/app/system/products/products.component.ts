import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Product } from 'src/app/shared/models/product.model';
import { ProductsService } from '../products.service';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];

  constructor(
    private snackbar: MatSnackBar,
    private productsService: ProductsService,
    public auth: AuthService
  ) {}

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productsService.getAllProducts().subscribe((p) => {
      this.products = p;
    });
  }

  addToCart(product: Product) {
    if (!this.auth.currentUserId) {
      this.snackbar.open('Войдите в систему', undefined, {
        duration: 2000,
      });
      return;
    }

    this.productsService
      .addProductToUser(this.auth.currentUserId, product.id)
      .subscribe({
        next: (r) => {
          this.snackbar.open('Упешно добавлено в корзину.', undefined, {
            duration: 1000,
          });
        },
        error: (err) => {
          this.snackbar.open('Ошибка добавления', undefined, {
            duration: 2000,
          });
        },
      });
  }
}
