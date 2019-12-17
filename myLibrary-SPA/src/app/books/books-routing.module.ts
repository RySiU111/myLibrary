import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookDashboardComponent } from './book-dashboard/book-dashboard.component';
import { BookFormComponent } from './book-form/book-form.component';
import { BookDetailedComponent } from './book-detailed/book-detailed.component';

const booksRoutes: Routes = [
  { path: 'form', component: BookFormComponent },
  { path: ':id', component: BookDetailedComponent },
  { path: '', component: BookDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forChild(booksRoutes)],
  exports: [RouterModule]
})
export class BooksRoutingModule { }
