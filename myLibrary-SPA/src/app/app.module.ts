import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './routes';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AppMaterialsModule } from './materials';
import { HttpClientModule } from '@angular/common/http';
import { BooksModule } from './books/books.module';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppMaterialsModule,
    HttpClientModule,
    BooksModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
