import { Category } from "./category.model";

export interface Flower {
    flowerId?: number | null;
    name: string;
    price:number;
    category?: Category | null; // Optional, for Category details
    categoryId?: number | null;
}