import { Component, Input, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CartService } from '../../services/cart/cart.service';
import CartProduct from '../../model/CartProduct';
import { ShoesColorPipe } from '../../pipes/shoesColor/shoes-color.pipe';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [ReactiveFormsModule, ShoesColorPipe],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss',
})
export class CheckoutComponent implements OnInit {
  subTotal: number = 0;
  total: number = 0;
  @Input() products: CartProduct[] = [];
  constructor(private cartService: CartService) {}
  
  ngOnInit(): void {
    this.cartService.total$.subscribe((value) => {
      this.subTotal = value.subtotal;
      this.total = value.total;
    });
    this.cartService.cartItems$.subscribe((items: CartProduct[]) => {
      this.products = items;
    });
  }
  
  addressForm = new FormGroup({
    name: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(2),
    ]),
    surname: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(2),
    ]),
    address: new FormControl<string>('', [Validators.required]),
    postalCode: new FormControl<string>('', [Validators.required]),
    city: new FormControl<string>('', [Validators.required]),
    country: new FormControl<string>('', [Validators.required]),
    email: new FormControl<string>('', [Validators.required, Validators.email]),
    phone: new FormControl<string>('', [
      Validators.required,
      Validators.pattern(/^[\d]{10}$/),
    ]),
  });

  addressSubmit() {
    this.name?.markAsTouched();
    this.surname?.markAsTouched();
    this.address?.markAsTouched();
    this.postalCode?.markAsTouched();
    this.city?.markAsTouched();
    this.country?.markAsTouched();
    this.email?.markAsTouched();
    this.phone?.markAsTouched();
    if (this.addressForm.valid) {
      console.log(this.addressForm.value);
    }
  }

  public get name() {
    return this.addressForm.get('name');
  }
  public get surname() {
    return this.addressForm.get('surname');
  }
  public get address() {
    return this.addressForm.get('address');
  }
  public get postalCode() {
    return this.addressForm.get('postalCode');
  }
  public get city() {
    return this.addressForm.get('city');
  }
  public get country() {
    return this.addressForm.get('country');
  }
  public get email() {
    return this.addressForm.get('email');
  }
  public get phone() {
    return this.addressForm.get('phone');
  }
}
