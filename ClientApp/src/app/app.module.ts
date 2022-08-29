import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import ProductPageView from './views/productPageView.component';
import { CartView } from './views/cartView.component';

@NgModule({
  declarations: [
        AppComponent,
        ProductPageView,
        CartView
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
    providers: [
        Store
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
