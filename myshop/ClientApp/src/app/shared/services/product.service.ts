import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CreateOrUpdateProduct } from "../models/create-or-update-product";
import { Product } from "../models/product";

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    constructor(private http: HttpClient) {}

    getProducts(categoryId?: number | undefined) {
        let url = '/api/products';
        if (categoryId) {
            url += `?categoryId=${categoryId}`;
        }
        return this.http.get<Product[]>(url);
    }

    createProduct(product: CreateOrUpdateProduct) {
        return this.http.post<number>('/api/products', product);
    }

    updateProduct(product: CreateOrUpdateProduct) {
        return this.http.put('/api/products', product);
    }

    deleteProduct(productId: number) {
        return this.http.delete(`/api/products/${productId}`);
    }
}