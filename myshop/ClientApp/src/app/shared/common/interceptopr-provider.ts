import { HttpInterceptor, HTTP_INTERCEPTORS } from "@angular/common/http";

export class HttpInterceptorProvider {
    public provide: any;
    public multi: boolean;
    public useClass: any;

    constructor(useClass: any) {
        this.provide = HTTP_INTERCEPTORS;
        this.multi = true;
        this.useClass = useClass;
    }

    static create(useClass: any) {
        return new HttpInterceptorProvider(useClass);
    }
}