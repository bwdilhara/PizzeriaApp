import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PizzaOrder } from './pizzaOrder';

import { Product } from './product';

@Injectable()
export class ProductService {

  apiUrl: string ="https://localhost:7099/api/Pizzerias";
  
  constructor(private http: HttpClient) { } 

  getProducts(locationId:string) {
    let params = new HttpParams().set('locationId', locationId);
    return this.http.get<any>(this.apiUrl, { params: params })
      .toPromise()
      .then(res => <Product[]>res)
      .then(data => { return data; });
  }

  placeProductOrder(pizzaOrder: PizzaOrder) {
    return this.http.post<number>(this.apiUrl, pizzaOrder)
      .toPromise()
      .then(res => <number>res);
  }
}
