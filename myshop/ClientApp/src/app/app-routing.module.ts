import { NgModule } from '@angular/core';
import { Route, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './products/product-list.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '',
    component: ProductListComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
