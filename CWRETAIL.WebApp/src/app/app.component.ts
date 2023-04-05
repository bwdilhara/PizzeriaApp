import { Component } from '@angular/core';
//import { ProductService } from './productservice';
import { Product } from './product';
import { SelectItem } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import { ProductService } from './productservice';
import { StoreLocation } from './location';
import { PizzaOrder } from './pizzaOrder';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'CWRETAIL.WebApp';
  locations: StoreLocation[];
  products: Product[];
  selectedLocation: string="1";
  sortOptions: SelectItem[];

  id: string;
  sortOrder: number;
  totalAmount: number=0;

  sortField: string;
  sortKey: string;
  customerId: string = "1";

  constructor(private productService: ProductService, private primengConfig: PrimeNGConfig) { }

  ngOnInit() {
    

    this.sortOptions = [
      { label: 'Price High to Low', value: '!price' },
      { label: 'Price Low to High', value: 'price' }
    ];

    this.primengConfig.ripple = true;

    this.locations = [{ name: 'Preston', code: '1' }, { name: 'Southbank', code: '2' }];
    this.productService.getProducts('1').then(data => this.products = data);
  }

  onSortChange(event) {
    let value = event.value;

    if (value.indexOf('!') === 0) {
      this.sortOrder = -1;
      this.sortField = value.substring(1, value.length);
    }
    else {
      this.sortOrder = 1;
      this.sortField = value;
    }
  }

  onLocationChange(event) {
    let value = event.value;
    this.selectedLocation = value;
    this.totalAmount = 0;
    this.productService.getProducts(value).then(data => this.products = data);
  }

  onShoppingCartClick(product){
    if (!product.quantity) {
      product.quantity = 1;
    } else {
      product.quantity += 1;
    }

    let pizzaOrder: PizzaOrder = {
      id:this.id,
      customerId: this.customerId,
      locationId: this.selectedLocation,
      items: this.products
    };

    this.productService.placeProductOrder(pizzaOrder).then(data => this.totalAmount = data)
  }
}
