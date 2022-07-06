import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Roles } from 'src/app/shared/common/constants';
import { AlertService } from 'src/app/shared/services/alert.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrderService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  form!: FormGroup;
  private subs?: Subscription;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private orderService: OrderService,
    private router: Router,
    private alertService: AlertService,
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnDestroy(): void {
    this.subs?.unsubscribe();
  }

  onSubmit() {
    if (this.form.invalid) return;
    const userName = this.form.get('userName')?.value;
    const password = this.form.get('password')?.value;
    this.authService.login(userName, password)
      .subscribe({
        next: response => {
          this.authService.saveAuthData(response);
          this.orderService.completePendingOrder();
          this.router.navigate(['/']);
        },
        error: (err) => {
          this.alertService.fail(err.error.message);
        }
      })
  }
}
