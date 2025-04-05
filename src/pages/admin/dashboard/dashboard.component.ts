import { products } from './../../../mock-product-list';
import { CommonModule } from '@angular/common';
import CatalogProduct from '../../../model/CatalogProduct';
import { StockstatusPipe } from '../../../pipes/status/stockstatus.pipe';
import { StatusColorPipe } from '../../../pipes/statusColor/status-color.pipe';
import { ProductService } from './../../../services/product-service/product.service';
import { Component, OnInit } from '@angular/core';
import { SearchBarComponent } from '../../../components/search-bar/search-bar.component';
import { Route, Router } from '@angular/router';
import { ToastService } from '../../../services/toast/toast.service';
import CartProduct, { Severity } from '../../../model/CartProduct';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [StockstatusPipe, StatusColorPipe, CommonModule, SearchBarComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit {
  products!: CatalogProduct[];
  searchInput: string = '';
  searchInputProduct!: CatalogProduct[];
  constructor(
    private productService: ProductService, 
    private router: Router,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.productService
      .getProducts()
      .subscribe((item) => (this.products = item));
  }

  searchProduct(value: string) {
    this.searchInputProduct = products.filter((item) =>
      item.name.toLowerCase().includes(value.toLowerCase())
    );
  }

  redirectToProductSettings(id: string) {
    this.router.navigate([`/admin/${id}`]);
  }

  editProduct(product: CatalogProduct) {
    this.router.navigate([`/admin/product-settings/${product.id}`]);
  }

  deleteProduct(product: CatalogProduct) {
    // In a real application, you would call an API to delete the product
    // For now, we'll just show a toast message
    this.toastService.displayGenericToast({
      severity: Severity.success,
      summary: 'Product Deleted',
      detail: `${product.name} has been deleted successfully.`
    });
    
    // Remove the product from the local array
    this.products = this.products.filter(p => p.id !== product.id);
  }
}
