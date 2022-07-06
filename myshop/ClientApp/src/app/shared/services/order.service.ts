import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { CreateOrder } from "../models/create-order";
import { CreateOrderResponse } from "../models/create-order-response";
import { AlertService } from "./alert.service";
import { AuthService } from "./auth.service";

@Injectable({
    providedIn: 'root'
})
export class OrderService {
    constructor(
        private http: HttpClient, 
        private authService: AuthService, 
        private alertService: AlertService) {}

    createOrder(order: CreateOrder) {
        return this.http.post<CreateOrderResponse>('/api/orders/', order);
    }

    completePendingOrder() {
        if (!this.authService.isAuthenticated) return;
        const orderId = localStorage.getItem("temp_order");
        if (!orderId || !parseInt(orderId)) return;
        
        this.http.get(`/api/orders/complete_order/${parseInt(orderId)}`)
            .subscribe({
                next: () => {
                    this.alertService.success(`Order #${orderId} completed successfully!`);
                    localStorage.removeItem('temp_order');
                },
                error: (err: HttpErrorResponse) => {
                    this.alertService.fail(err.error.message, "OK");
                }
            })
    }
}