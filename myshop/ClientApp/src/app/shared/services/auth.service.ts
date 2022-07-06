import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { CurrentUser } from "../models/current-user";
import { LoginResponse } from "../models/login-response";
import { RegisterCustomer } from "../models/register-customer";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private _isAuthenticated$ = new BehaviorSubject<boolean>(false);
    private _currentUser$ = new BehaviorSubject<CurrentUser | null>(null);

    get isAuthenticated() {
        return this._isAuthenticated$.value;
    }

    get isAuthenticated$() {
        return this._isAuthenticated$.asObservable();
    }

    get currentUser() {
        return this._currentUser$.value;
    }

    get currentUser$() {
        return this._currentUser$.asObservable();
    }

    get token() {
        const data = this.getAuthData();
        return data?.token;
    }

    get isTokenExpired() {
        const data = this.getAuthData();
        return !data?.expiresAt || new Date(data.expiresAt) < new Date();
    }

    constructor(private http: HttpClient, private router: Router) { }

    registerCustomer(customer: RegisterCustomer) {
        return this.http.post<LoginResponse>('/api/auth/register', customer);
    }

    login(userName: string, password: string) {
        return this.http.post<LoginResponse>('/api/auth', {
            userName,
            password,
        });
    }

    logout() {
        localStorage.removeItem("user");
        localStorage.removeItem("temp_order");
        this._isAuthenticated$.next(false);
        this._currentUser$.next(null);
        this.router.navigate(['/login']);
    }

    saveAuthData(loginResponse: LoginResponse) {
        localStorage.setItem("user", JSON.stringify(loginResponse));
        this.initAuth();
    }

    getAuthData(): LoginResponse | null {
        var data = localStorage.getItem("user");
        if (data) {
            return JSON.parse(data) as LoginResponse;
        } else {
            return null;
        }
    }

    initAuth() {
        var data = this.getAuthData();
        if (data) {
            this._isAuthenticated$.next(true);
            this._currentUser$.next(data as CurrentUser);
        }
    }
    
    hasRole(role: string): boolean {
        if (!this.currentUser || !this.currentUser.roles) {
            return false;
        }
        return this.currentUser.roles.indexOf(role) != -1;
    }
}