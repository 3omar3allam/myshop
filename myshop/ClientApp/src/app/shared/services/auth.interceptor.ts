import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { AuthService } from "./auth.service";

@Injectable({
    providedIn: 'root',
})
export class AuthInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.indexOf("/api/") != -1) {
            const token = this.authService.token;
            if (token) {
                return next.handle(req.clone({
                    headers: req.headers.set("Authorization", `Bearer ${token}`)
                }));
            }
        }
        return next.handle(req);
    }
}