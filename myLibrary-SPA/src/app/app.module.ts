import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { MaterialModule } from './material';


import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { BooksService } from './_services/books.service';
import { BookDetailedComponent } from './book-detailed/book-detailed.component';
import { BookFormComponent } from './book-form/book-form.component';
import { BookListComponent } from './book-list/book-list.component';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      BookDetailedComponent,
      BookFormComponent,
      BookListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes),
      MaterialModule
   ],
   providers: [
      BooksService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
