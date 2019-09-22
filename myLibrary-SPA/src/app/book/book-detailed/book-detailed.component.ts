import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { BooksService } from '../../_services/books.service';

@Component({
  selector: 'app-book-detailed',
  templateUrl: './book-detailed.component.html',
  styleUrls: ['./book-detailed.component.css']
})
export class BookDetailedComponent implements OnInit {

  id: any;
  book: any;

  constructor(private booksService: BooksService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe( paramMap => {
      console.log(paramMap);
      this.id = paramMap.get('id');
    }, error => {
      console.log('error')
    });
   }

  ngOnInit() {
    this.getBook();
  }

  getBook() {
    this.booksService.getBook(this.id).subscribe(response => {
      this.book = response;
    }, error => {
      console.log('error');
    });
  }

  deleteBook() {
    this.booksService.deleteBook(this.id).subscribe(response => {
      console.log('deleted');
    }, error => {
      console.log(error);
    });
  }

}
