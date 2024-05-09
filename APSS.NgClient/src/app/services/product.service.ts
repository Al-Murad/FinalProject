import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/data/product';
import { apiUrl } from '../shared/app-constants';
import { ProductCategory } from '../models/data/product-category';
import { VehicleType } from '../models/data/vehicle-type';
import { CommonDetail } from '../models/data/common-detail';
import { ImagePathResponse } from '../viewmodels/image-path-response';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  get():Observable<Product[]>{
    return this.http.get<Product[]>(`${apiUrl}/api/Products`);
  }
  getCategories():Observable<ProductCategory[]>{
    return this.http.get<ProductCategory[]>(`${apiUrl}/api/ProductCategories`)
  }
  getCategoriesOf(id:number):Observable<ProductCategory[]>{
    return this.http.get<ProductCategory[]>(`${apiUrl}/api/ProductCategories/Of/${id}`)
  }
  getVehicleTypes():Observable<VehicleType[]>{
    return this.http.get<VehicleType[]>(`${apiUrl}/api/VehicleTypes`)
  }
  getCommonDetails():Observable<CommonDetail[]>{
    return this.http.get<CommonDetail[]>(`${apiUrl}/api/CommonDetails`)
  }
  create(data:Product):Observable<Product>{
    return this.http.post<Product>(`${apiUrl}/api/Products`, data);
  }
  uploadImages(id:number, files:File[]):Observable<ImagePathResponse[]>{
    var fd = new FormData();
    for (let i = 0; i < files.length; i++) {
      fd.append("files", files[i], files[i].name);
      
    }
    return this.http.post<ImagePathResponse[]>(`${apiUrl}/api/Images/Upload/${id}`, fd);
  }
}
