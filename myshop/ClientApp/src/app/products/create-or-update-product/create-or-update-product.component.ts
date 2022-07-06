import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from 'src/app/shared/models/product';
import { AlertService } from 'src/app/shared/services/alert.service';
import { ProductService } from 'src/app/shared/services/product.service';

@Component({
  selector: 'app-create-or-update-product',
  templateUrl: './create-or-update-product.component.html',
  styleUrls: ['./create-or-update-product.component.scss']
})
export class CreateOrUpdateProductComponent implements OnInit {
  edit = false;
  form!: FormGroup;
  hasDiscount = false;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CreateOrUpdateProductComponent>,
    private productService: ProductService,
    private alertService: AlertService,
    @Inject(MAT_DIALOG_DATA) private data?: Product) { }

  ngOnInit(): void {
    this.dialogRef
    this.initForm();

    if (this.data && this.data.id) {
      const { discount, ...product } = this.data;
      this.form.patchValue(product);
      if (discount) {
        this.form.patchValue({
          discountQuantity: discount.quantity,
          discountPercentage: discount.percentage,
        });
        this.hasDiscount = true;
      }
      this.edit = true;
    }
  }

  onSubmit() {
    if (this.edit) {
      this.productService.updateProduct(this.form.getRawValue())
        .subscribe({
          next: () => {
            this.alertService.success("Product updated successfully");
            this.dialogRef.close();
          },
          error: (err) => this.alertService.fail(err.error.message),
        });
    } else {
      this.productService.createProduct(this.form.getRawValue())
        .subscribe({
          next: () => {
            this.alertService.success("Product added successfully");
            this.dialogRef.close();
          },
          error: (err) => this.alertService.fail(err.error.message),
        });
    }
  }

  onChangeCategory(categoryId?: number | undefined) {
    this.form.get('categoryId')?.setValue(categoryId);
    if (!categoryId) {
      this.form.get('categoryId')?.setErrors({
        required: true,
      });
    }
  }

  toggleDiscount() {
    this.hasDiscount = !this.hasDiscount;
    if (!this.hasDiscount) {
      this.form.patchValue({
        discountQuantity: 0,
        discountPercentage: 0,
      })
    }
  }

  isErrorState(control: AbstractControl | null) {
    return (control?.dirty || control?.touched) && control?.invalid
  }

  private initForm() {
    this.form = this.fb.group({
      id: [0],
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.maxLength(500)]],
      categoryId: [null, [Validators.required]],
      price: [0, [Validators.required, Validators.min(0)]],
      discountQuantity: [0, [Validators.required, Validators.min(0)]],
      discountPercentage: [0, [Validators.required, Validators.min(0), Validators.max(100)]],
    })
  }
}
