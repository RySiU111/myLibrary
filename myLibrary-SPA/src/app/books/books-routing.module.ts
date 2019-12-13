import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookDashboardComponent } from './book-dashboard/book-dashboard.component';
import { BookFormComponent } from './book-form/book-form.component';

const booksRoutes: Routes = [
  { path: 'form', component: BookFormComponent },
  { path: '', component: BookDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forChild(booksRoutes)],
  exports: [RouterModule]
})
export class BooksRoutingModule { }
