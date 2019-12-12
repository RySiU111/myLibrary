import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookDashboardComponent } from './book-dashboard/book-dashboard.component';
import { BookCardComponent } from './book-card/book-card.component';
import { BookService } from './services/book.service';
import { AppMaterialsModule } from '../materials';



@NgModule({
  declarations: [
    BookDashboardComponent,
    BookCardComponent
  ],
  exports: [
    BookDashboardComponent,
    BookCardComponent
  ],
  imports: [
    CommonModule,
    AppMaterialsModule
  ],
  providers: [
    BookService
  ]
})
export class BooksModule { }
