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
        if (req.url.startsWith('/api/')) {
            req = req.clone({
                withCredentials: true,
            });
            // if (!req.url.startsWith('/api/auth')) {
            //     if (this.authService.isAuthenticated && this.authService.isTokenExpired) {
            //         return this.authService.refresh()
            //             .pipe(mergeMap(() => next.handle(req)));
            //     }
            // }
        }
        return next.handle(req);
    }
}