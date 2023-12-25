import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Product, ProductDto } from '../shared/models/product.model';

@Injectable({ providedIn: 'root' })
export class ProductsService {
  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<Product[]> {
    return this.http
      .get<ProductDto[]>('https://localhost:7176/api/products')
      .pipe(
        map((p) => {
          return p.map((p) => {
            return { ...p, cartCount: 1 };
          });
        })
      );
  }

  getAllUserProducts(userId: number): Observable<Product[]> {
    return this.http
      .get<ProductDto[]>(`https://localhost:7176/api/users/${userId}/products`)
      .pipe(
        map((p) => {
          return p.map((p) => {
            return { ...p, cartCount: 1 };
          });
        })
      );
  }

  addProductToUser(userId: number, productId: number): Observable<string> {
    return this.http.post<string>(
      `https://localhost:7176/api/users/${userId}/products/${productId}`,
      {}
    );
  }

  deleteProductFromUser(userId: number, productId: number) {
    return this.http.delete(
      `https://localhost:7176/api/users/${userId}/products/${productId}`
    );
  }

  removeAllProductsFromUser(userId: number) {
    return this.http.delete(
      `https://localhost:7176/api/users/${userId}/products`
    );
  }
}
