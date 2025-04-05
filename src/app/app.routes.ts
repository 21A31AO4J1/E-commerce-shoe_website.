import { Routes } from '@angular/router';
import { ShopComponent } from './pages/shop/shop.component';
import { HomeComponent } from './pages/home/home.component';
import { MyaccountComponent } from './pages/myaccount/myaccount.component';
import { AboutComponent } from './pages/about/about.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ShopDetailsComponent } from './pages/shop-details/shop-details.component';
import { CartComponent } from './pages/cart/cart.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { DashboardComponent } from './pages/admin/dashboard/dashboard.component';
import { ProductSettingsComponent } from './pages/admin/product-settings/product-settings.component';
import { AdminGuard } from './guards/admin.guard';
import { ProfileComponent } from './pages/profile/profile.component';
import { userLoggedGuard } from './guards/user-logged.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  { path: 'home', component: HomeComponent },
  { path: 'shop', component: ShopComponent },
  { path: 'shop/:id', component: ShopDetailsComponent },
  { path: 'myaccount', component: MyaccountComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'cart', component: CartComponent },
  { path: 'checkout', component: CheckoutComponent },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [userLoggedGuard],
  },
  {
    path: 'admin',
    component: DashboardComponent,
    canActivate: [AdminGuard],
  },
  {
    path: 'admin/:id',
    component: ProductSettingsComponent,
    canActivate: [AdminGuard],
  },
  { path: '**', component: HomeComponent },
];  