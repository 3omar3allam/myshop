import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'My Shop';

  isAuthenticated!: boolean;
  userName?: string;

  private subs?: Subscription

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.initAuth();
    
    this.subs = this.authService.currentUser$
      .subscribe((user) => {
        this.userName = user?.name;
        this.isAuthenticated = !!this.userName;
      })
  }

  ngOnDestroy(): void {
    this.subs?.unsubscribe;
  }

  logout() {
    this.authService.logout();
  }
}
