import { Injectable } from '@angular/core';
import CartProduct, { Severity } from '../../model/CartProduct';
import { BehaviorSubject } from 'rxjs';
import CatalogProduct from '../../model/CatalogProduct';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems = new BehaviorSubject<CartProduct[]>([]);
  cartItems$ = this.cartItems.asObservable();

  private total = new BehaviorSubject<{ subtotal: number; total: number }>({
    subtotal: 0,
    total: 0
  });
  total$ = this.total.asObservable();

  quantityOfProductsInCart: number = 0;

  constructor() {}

  addToCart(product: CatalogProduct): void {
    const currentItems = this.cartItems.value;
    const existingItem = currentItems.find(item => item.id === product.id);

    if (existingItem) {
      existingItem.updateQuantity();
    } else {
      const newItem = this.createCartProduct(product);
      this.cartItems.next([...currentItems, newItem]);
    }
    this.calculateTotal();
  }

  createCartProduct(product: CatalogProduct): CartProduct {
    return new CartProduct(
      product.id,
      product.name,
      product.title,
      product.description,
      product.price,
      product.category,
      product.brand,
      product.size,
      product.color,
      product.imageUrl,
      [], // details array is empty since we don't have it anymore
      Severity.success
    );
  }

  removeFromCart(productId: string): void {
    const currentItems = this.cartItems.value;
    this.cartItems.next(currentItems.filter(item => item.id !== productId));
    this.calculateTotal();
  }

  clearCart(): void {
    this.cartItems.next([]);
    this.calculateTotal();
  }

  calculateTotal(): void {
    const subtotal = this.cartItems.value.reduce((acc, product) => {
      return product.quantity * product.price + acc;
    }, 0);

    this.total.next({
      subtotal,
      total: subtotal
    });
  }
}
