export interface CreateOrUpdateProduct {
    id: number;
    name: string;
    description?: string;
    categoryId: number;
    price: number;
    discountQuantity?: number;
    discountPercentage?: number;
}