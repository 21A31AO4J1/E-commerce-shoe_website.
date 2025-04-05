import { Injectable } from '@angular/core';
import CatalogProduct from '../../model/CatalogProduct';
import { catchError, Observable, of, tap, throwError } from 'rxjs';
import { products } from '../../mock-product-list';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private url: string = environment.apiURL + '/products';

  constructor(private http: HttpClient) {}

  getProducts(): Observable<CatalogProduct[]> {
    // Use mock data instead of making an HTTP request
    return of(products).pipe(
      tap((product) => {}),
      catchError((error) => {
        console.error('Error fetching products', error);
        return throwError(() => new Error('Failed fetch'));
      })
    );
  }

  getProductById(productId: string): Observable<CatalogProduct> {
    // Find the product in the mock data
    const product = products.find(p => p.id === productId);
    if (product) {
      return of(product).pipe(
        tap((product) => {
          console.log(product);
        }),
        catchError((error) => {
          console.error('Error fetching product', error);
          return throwError(() => new Error('Failed fetch'));
        })
      );
    } else {
      return throwError(() => new Error('Product not found'));
    }
  }

  upDateProduct(catalogProduct: CatalogProduct): Observable<CatalogProduct> {
    // For mock implementation, just return the product
    return of(catalogProduct).pipe(
      tap((product) => {
        console.log('Product updated:', product);
      }),
      catchError((error) => {
        console.error('Error updating product', error);
        return throwError(() => new Error('Failed to update product'));
      })
    );
  }
}
