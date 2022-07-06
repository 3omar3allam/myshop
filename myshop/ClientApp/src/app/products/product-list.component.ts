import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable, Subject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';
import { Product } from 'src/app/shared/models/product';
import { ProductService } from 'src/app/shared/services/product.service';
import { Roles } from '../shared/common/constants';
import { AlertService } from '../shared/services/alert.service';
import { AuthService } from '../shared/services/auth.service';
import { CreateOrUpdateProductComponent } from './create-or-update-product/create-or-update-product.component';
import { PurchaseProductComponent } from './purchase-product/purchase-product.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit, OnDestroy {
  products$!: Observable<Product[]>;
  isAdmin$!: Observable<boolean>;
  categoryId?: number;

  private unsubsribe$ = new Subject<void>();

  constructor(
    private productService: ProductService,
    private dialog: MatDialog,
    private authService: AuthService,
    private alertService: AlertService,
    ) { }

  ngOnInit(): void {
    this.fetchProducts();
    this.isAdmin$ = this.authService.currentUser$
      .pipe(map(user => {
        return user && this.authService.hasRole(Roles.ADMIN) || false;
      }));
  }

  ngOnDestroy(): void {
    this.unsubsribe$.next();
    this.unsubsribe$.complete();
  }

  onChangeCategory(categoryId?: number) {
    this.categoryId = categoryId;
    this.fetchProducts();
  }

  fetchProducts() {
    this.products$ = this.productService.getProducts(this.categoryId);
  }
  
  openPurchaseModal(product: Product) {
    this.dialog.open(PurchaseProductComponent, {
      data: product,
    });
  }

  addProduct() {
    this.dialog.open(CreateOrUpdateProductComponent)
      .afterClosed()
      .pipe(takeUntil(this.unsubsribe$))
      .subscribe(() => this.fetchProducts());
  }

  updateProduct(product: Product) {
    this.dialog.open(CreateOrUpdateProductComponent, {
      data: product,
    }).afterClosed()
      .pipe(takeUntil(this.unsubsribe$))
      .subscribe(() => this.fetchProducts());
  }

  deleteProduct(product: Product) {
    this.productService.deleteProduct(product.id)
      .subscribe({
        next: () => {
          this.alertService.success("Product deleted successfully");
          this.fetchProducts();
        },
        error: err => {
          this.alertService.fail(err.error.message);
        }
      });
  }
}
