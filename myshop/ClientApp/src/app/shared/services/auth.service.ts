import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { CurrentUser } from "../models/current-user";
import { LoginResponse } from "../models/login-response";
import { RegisterCustomer } from "../models/register-customer";

const LOCAL_STORAGE_KEY = 'myshop:user';

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

    get isTokenExpired() {
        var data = this.getAuthData();
        return !data?.expiresAt || new Date(data.expiresAt) < new Date()
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
        localStorage.removeItem(LOCAL_STORAGE_KEY);
        this._isAuthenticated$.next(false);
        this._currentUser$.next(null);
        this.router.navigate(['/login']);
    }

    saveAuthData(loginResponse: LoginResponse) {
        localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(loginResponse));
        this.initAuth();
    }

    getAuthData(): LoginResponse | null {
        var data = localStorage.getItem(LOCAL_STORAGE_KEY);
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