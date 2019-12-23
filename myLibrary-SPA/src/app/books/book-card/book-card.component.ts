import { Component, OnInit, Input } from '@angular/core';
import { BookService, Book } from '../services/book.service';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent implements OnInit {
  @Input() book: Book;
  @Input() disableLink;

  constructor(private bookService: BookService) { }

  ngOnInit() {
  }

}
