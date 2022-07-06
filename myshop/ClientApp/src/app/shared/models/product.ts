import { Discount } from "./discount";

export interface Product {
    id: number;
    name: string;
    description?: string;
    categoryId: number;
    categoryName: string;
    price: number;
    discount?: Discount;
}