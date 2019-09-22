import { Component, OnInit } from '@angular/core';
import { BooksService } from '../../_services/books.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  constructor(private booksService: BooksService) { }

  book: any = {};

  ngOnInit() {
  }

  postBook() {
    this.booksService.postBook(this.book).subscribe(response => {
      console.log('success');
    }, error => {
      console.log('error');
    });
  }
}
