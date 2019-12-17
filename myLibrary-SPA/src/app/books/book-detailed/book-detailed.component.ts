import { Component, OnInit } from '@angular/core';
import { BookService, Book } from '../services/book.service';
import { Params, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-detailed',
  templateUrl: './book-detailed.component.html',
  styleUrls: ['./book-detailed.component.css']
})
export class BookDetailedComponent implements OnInit {

  book: Book;
  id: number;

  constructor(private service: BookService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params: Params) => {
      this.id = params.get('id');
    }, error => {
      console.log(error);
    });
   }

  ngOnInit() {
    this.getBook(this.id);
  }

  getBook(id: number) {
    this.service.getBook(id).subscribe(response => {
      this.book = response;
    }, error => {
      console.log(error);
    });
  }

}
