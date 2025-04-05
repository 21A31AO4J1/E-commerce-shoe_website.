import { Component, Input, OnInit } from '@angular/core';
import CatalogProduct from '../../model/CatalogProduct';
import { TabViewModule } from 'primeng/tabview';
import { AccordionModule } from 'primeng/accordion';
import { CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { CartService } from '../../services/cart/cart.service';
import CartProduct, {
  GenericToastProps,
  Severity,
} from '../../model/CartProduct';
import { ToastService } from '../../services/toast/toast.service';
import { ShoesColorPipe } from '../../pipes/shoesColor/shoes-color.pipe';

@Component({
  selector: 'app-shop-product-details',
  standalone: true,
  imports: [
    TabViewModule,
    AccordionModule,
    CommonModule,
    ReactiveFormsModule,
    ShoesColorPipe,
  ],
  templateUrl: './shop-product-details.component.html',
  styleUrl: './shop-product-details.component.scss',
})
export class ShopProductDetailsComponent implements OnInit {
  @Input() product!: CatalogProduct;

  productForm = new FormGroup({
    productId: new FormControl<number>(0),
    productName: new FormControl<string>(''),
    productTitle: new FormControl<string>(''),
    productDescription: new FormControl<string>(''),
    productPrice: new FormControl<number>(0),
    productCategory: new FormControl<string>(''),
    productColor: new FormControl<string>('', Validators.required),
    productSize: new FormControl<string>('', Validators.required),
    productImageUrl: new FormControl<string>(''),
    productCreatedAt: new FormControl<Date>(new Date()),
    productUpdatedAt: new FormControl<Date>(new Date()),
  });

  constructor(
    private cartService: CartService,
    private toastService: ToastService
  ) {}

  productIsNotAvailable: boolean = false;

  ngOnInit() {
    // Set default color and size
    this.productForm.get('productColor')?.setValue(this.product.color);
    this.productForm.get('productSize')?.setValue(this.product.size);
    
    // Check if product is available
    this.productIsNotAvailable = this.product.stockQuantity < 1;
  }

  createNewcartItem(): CartProduct {
    return new CartProduct(
      this.product.id,
      this.product.name,
      this.product.title,
      this.product.description,
      this.product.price,
      this.product.category,
      this.product.brand,
      this.product.size,
      this.product.color,
      this.product.imageUrl,
      [], // Empty array for details
      Severity.success
    );
  }

  addProductToCart(): void {
    this.productForm.get('productSize')?.markAsTouched();
    if (this.productForm.valid) {
      this.cartService.addToCart(this.product);
      this.toastService.displayGenericToast({
        severity: Severity.success,
        summary: 'Success',
        detail: 'Product added to cart',
      });
    }
  }

  addProductToFavorites() {
    const genericToastProps: GenericToastProps = {
      severity: Severity.success,
      summary: 'Product Saved',
      detail: 'Product added to you favorites',
    };
    this.toastService.displayGenericToast(genericToastProps);
  }
}