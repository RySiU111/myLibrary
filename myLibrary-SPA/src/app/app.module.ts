import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { MaterialModule } from './material';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';


import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { BooksService } from './_services/books.service';
import { BookDetailedComponent } from './book/book-detailed/book-detailed.component';
import { BookFormComponent } from './book/book-form/book-form.component';
import { BookListComponent } from './book/book-list/book-list.component';




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
      MaterialModule,
      FormsModule
   ],
   providers: [
      BooksService,
      DatePipe
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
