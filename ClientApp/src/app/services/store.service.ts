import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { LoginRequest, LoginResults } from "../shared/LoginResults";
import { Order, OrderItem } from "../shared/Order";
import { Product } from "../shared/Product";

@Injectable()
export class Store {

    constructor(private http: HttpClient) { }

    public products: Product[] = [];
    public order: Order = new Order();
    public token = "";
    public exp = new Date();

    get loginReq(): boolean {
        return this.token.length === 0 || this.exp > new Date();
    }

    login(creds: LoginRequest) {
        return this.http.post<LoginResults>("/account/CreateToken", creds)
            .pipe(map(data => {
                this.token = data.token;
                this.exp = data.expiration;
            }));
    }

    checkout() {
        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`)
        return this.http.post("/api/order", this.order, {
            headers: headers
        }).pipe(map(() => {
            this.order = new Order();
        }));
    }

    loadProduct(): Observable<void> {
        return this.http.get<[]>("/api/product")
            .pipe(map(data => {
                this.products = data;
                return;
            }));
    }

    addToOrder(product: Product) {

        let item: OrderItem | undefined;

        item = this.order.Items.find(o => o.productId === product.productNumber);

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
            this.order.Items.push(item);
        }
    }
}