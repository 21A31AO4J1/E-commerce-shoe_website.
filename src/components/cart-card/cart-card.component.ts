import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import CartProduct from '../../model/CartProduct';
import { CartService } from '../../services/cart/cart.service';
import { ShoesColorPipe } from '../../pipes/shoesColor/shoes-color.pipe';

@Component({
  selector: 'app-cart-card',
  standalone: true,
  imports: [CommonModule, ShoesColorPipe],
  templateUrl: './cart-card.component.html',
  styleUrl: './cart-card.component.scss',
})
export class CartCardComponent {
  constructor(private cartService: CartService) {}

  @Input() product!: CartProduct;

  addItem() {
    this.product.quantity += 1;
    if (this.product.quantity > 10) this.product.quantity = 10;
    this.cartService.calculateTotal();
  }
  
  removeItem() {
    this.product.quantity -= 1;
    if (this.product.quantity < 1) {
      this.product.quantity = 0;
      this.cartService.removeFromCart(this.product.id);
    }
    this.cartService.calculateTotal();
  }

  removeFromCart(): void {
    this.cartService.removeFromCart(this.product.id);
  }
}
