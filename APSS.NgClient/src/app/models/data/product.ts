import { ProductCategory } from "./product-category";
import { ProductDetail } from "./product-detail";

export interface Product {
    productId?:number;
    productName?:string;
    price?:number;
    shortDescription?:string;
    productCategoryId?:number
    productCategory?:ProductCategory;
    productDetails?:ProductDetail[];
}
