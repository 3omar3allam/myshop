import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Roles } from 'src/app/shared/common/constants';
import { AlertService } from 'src/app/shared/services/alert.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { OrderService } from 'src/app/shared/services/order.service';
import { mustMatch } from './password-match.validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit, OnDestroy {
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
      userName: ['', [Validators.required, Validators.maxLength(25), Validators.pattern("^[a-zA-Z0-9_]*$")]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4)]],
      confirmPassword: ['', Validators.required],
      displayName: ['', [Validators.required, Validators.maxLength(50), Validators.pattern("^[a-zA-Z0-9_ ]*$")]]
    }, {
      validators: [mustMatch('password', 'confirmPassword')]
    });
  }

  ngOnDestroy(): void {
    this.subs?.unsubscribe();
  }

  onSubmit() {
    if (this.form.invalid) return;
    this.authService.registerCustomer(this.form.getRawValue())
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

  isErrorState(control: AbstractControl | null) {
    return (control?.dirty || control?.touched) && control?.invalid
  }
}
