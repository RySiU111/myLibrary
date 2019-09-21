import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BookDetailedComponent } from './book-detailed/book-detailed.component';
import { BookFormComponent } from './book-form/book-form.component';
import { BookListComponent } from './book-list/book-list.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'books', component: BookListComponent,
    children: [{ path: 'form', component: BookFormComponent }]},
    { path: 'books/:id', component: BookDetailedComponent },
    { path: 'form', component: BookFormComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
