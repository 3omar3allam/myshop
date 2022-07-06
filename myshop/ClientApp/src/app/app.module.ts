import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './register/register.component';
import { PurchaseProductComponent } from './products/purchase-product/purchase-product.component';
import { CategoryListComponent } from './products/category-list/category-list.component';
import { ProductListComponent } from './products/product-list.component';
import { LoginComponent } from './login/login.component';
import { ProductComponent } from './products/product/product.component';
import { ProductDiscountComponent } from './products/product/product-discount/product-discount.component';
import { CreateOrUpdateProductComponent } from './products/create-or-update-product/create-or-update-product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProductListComponent,
    CategoryListComponent,
    PurchaseProductComponent,
    RegisterComponent,
    ProductComponent,
    ProductDiscountComponent,
    CreateOrUpdateProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatSnackBarModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
