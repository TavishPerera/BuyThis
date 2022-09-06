import { Component, OnInit } from "@angular/core";
import { Store } from "../services/store.service";

@Component({
    selector:"product",
    templateUrl: "./productPageView.component.html",
    styleUrls: ["./productPageView.component.css"]
})

export default class ProductPageView implements OnInit {
    constructor(public store: Store) {}
    ngOnInit(): void {
        this.store.loadProduct().subscribe();
    }
}