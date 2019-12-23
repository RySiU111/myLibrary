import { Component, OnInit } from '@angular/core';
import { BookService, Book } from 'src/app/books/services/book.service';

@Component({
  selector: 'app-book-dashboard',
  templateUrl: './book-dashboard.component.html',
  styleUrls: ['./book-dashboard.component.css']
})
export class BookDashboardComponent implements OnInit {

  books: Book[];

  constructor(private service: BookService) { }

  ngOnInit() {
    this.getBooks();
  }

  getBooks() {
    this.service.getBooks().subscribe(response => {
      this.books = response;
    }, error => {
      console.log(error);
    });
  }
}
