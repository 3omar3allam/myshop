import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ErrorResponse } from 'src/app/shared/models/error-response';
import { Product } from 'src/app/shared/models/product';
import { AlertService } from 'src/app/shared/services/alert.service';
import { OrderService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-purchase-product',
  templateUrl: './purchase-product.component.html',
  styleUrls: ['./purchase-product.component.scss']
})
export class PurchaseProductComponent implements OnDestroy{
  quantity = 1;
  hasDiscount = false;
  originalPrice = 0;

  subs?: Subscription;

  get invalidQuantity() {
    return this.quantity <= 0 || this.quantity > 100;
  }
  
  get finalPrice() {
    if (this.quantity <= 0) {
      this.hasDiscount = false;
      return 0;
    }
    if (!this.product.discount || this.product.discount.quantity > this.quantity || this.product.discount.percentage == 0) {
      this.hasDiscount = false;
      return this.quantity * this.product.price;
    }
    this.originalPrice = this.quantity * this.product.price;
    this.hasDiscount = true;
    return this.originalPrice * (1 - this.product.discount.percentage);
  }


  constructor(
    @Inject(MAT_DIALOG_DATA) public product: Product,
    private dialogRef: MatDialogRef<PurchaseProductComponent>,
    private orderService: OrderService,
    private router: Router,
    private alertService: AlertService,
  ) { }

  ngOnDestroy(): void {
    this.subs?.unsubscribe();
  }

  createOrder() {
    if (this.invalidQuantity) return;
    this.orderService.createOrder({
      productId: this.product.id,
      quantity: this.quantity,
    }).subscribe({
      next: response => {
        if (response.registrationNeeded) {
          this.handleRegistrationNeeded(response.orderId);
          return;
        }
        this.alertService.success("Order places successfully!")
        this.dialogRef.close();
      },
      error: (err : HttpErrorResponse) => {
        this.alertService.fail(err.error.message);
      }
    })
  }

  handleRegistrationNeeded(orderId: number) {
    localStorage.setItem("temp_order", orderId.toString());
    
    this.subs = this.alertService.fail("Please login to complete your order", "Login/Register")
      .afterDismissed()
      .subscribe((value) => {
        if (value.dismissedByAction) {
          this.router.navigate(['/login']);
        }
        this.dialogRef.close();
      });
  }
}
