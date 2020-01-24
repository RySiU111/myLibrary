import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './routes';
import { AppMaterialsModule } from './materials';
import { HttpClientModule } from '@angular/common/http';
import { BooksModule } from './books/books.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { AppService } from './services/app.service';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AppMaterialsModule,
    HttpClientModule,
    BooksModule
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
