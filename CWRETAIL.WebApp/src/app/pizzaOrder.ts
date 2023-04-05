import { Product } from "./product";

export interface PizzaOrder {
  id?: string;
  locationId?: string;
  customerId?: string;
  orderDate?: Date;
  price?: number;
  items?: Product[];
}
