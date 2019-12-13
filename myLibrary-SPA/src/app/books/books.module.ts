import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookDashboardComponent } from './book-dashboard/book-dashboard.component';
import { BookCardComponent } from './book-card/book-card.component';
import { BookService } from './services/book.service';
import { AppMaterialsModule } from '../materials';
import { BooksRoutingModule } from './books-routing.module';
import { BookFormComponent } from './book-form/book-form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    BookDashboardComponent,
    BookCardComponent,
    BookFormComponent
  ],
  imports: [
    CommonModule,
    AppMaterialsModule,
    BooksRoutingModule,
    FormsModule
  ],
  providers: [
    BookService
  ]
})
export class BooksModule { }
