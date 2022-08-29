import { Component, OnInit } from "@angular/core";
import { Store } from "../services/store.service";

@Component({
    selector:"product",
    templateUrl: "./productPageView.component.html",
    styleUrls: ["./productPageView.component.css"]
})

export default class ProductPageView implements OnInit {

    constructor(public store: Store) {

    }

    ngOnInit(): void {
        this.store.loadProduct().subscribe();
    }


    //public products: any[] = [];

    //constructor(private store: Store) { 
    //    this.products = store.products;
    //}

    //public products = [{
    //    title: "Van",
    //    price: "16"
    //}, {
    //    title: "Car",
    //    price: "20"
    //}];
}