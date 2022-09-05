import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { Order, OrderItem } from "../shared/Order";
import { Product } from "../shared/Product";

@Injectable()
export class Store {

    constructor(private http: HttpClient) {

    }

    public products: Product[] = [];

    public order: Order = new Order();

    loadProduct(): Observable<void> {
        return this.http.get<[]>("/api/product")
            .pipe(map(data => {
                this.products = data;
                return;
            }));
    }

    addToOrder(product: Product) {

        let item: OrderItem | undefined;

        item = this.order.items.find(o => o.productNumber === product.productNumber);

        if (item?.quantity !== undefined) {
            item.quantity ++;
        } else {
            item = new OrderItem();
            item.productId = product.productId;
            item.productNumber = product.productNumber;
            item.productName = product.productName;
            item.productPicture = product.productPicture;
            item.productPrice = product.productPrice;
            item.productDescription = product.productDescription;
            item.quantity = 1;
            item.unitPrice = product.productPrice;
            this.order.items.push(item);
        }
    }
}