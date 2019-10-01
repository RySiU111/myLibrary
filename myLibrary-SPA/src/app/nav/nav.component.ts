import { Component, OnInit } from '@angular/core';
import { BooksService } from '../_services/books.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  search: string;
  book: any;

  constructor(private bookService: BooksService) { }

  ngOnInit() {
  }

  searchBook() {
    this.bookService.searchBook(this.search).subscribe(response => {
      this.book = response;
      if (this.book == null) {
        console.log('not found');
      } else {
        window.location.href = this.bookService.localhost + '/books/' + this.book.id;
      }
    }, error => {
      console.log(error);
    });
  }

}
