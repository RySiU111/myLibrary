import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BookDetailedComponent } from './book/book-detailed/book-detailed.component';
import { BookFormComponent } from './book/book-form/book-form.component';
import { BookListComponent } from './book/book-list/book-list.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'books', component: BookListComponent,
        children: [ { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: BookListComponent }]},
    { path: 'books', component: BookFormComponent,
        children: [ { path: '', redirectTo: 'form', pathMatch: 'full' },
            { path: 'form', component: BookFormComponent }]},
    { path: 'books/:id', component: BookDetailedComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
