import { Component, OnInit } from '@angular/core';
import { BooksService } from '../../_services/books.service';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  id: any;
  book: any;

  constructor(private booksService: BooksService, private route: ActivatedRoute, private datePipe: DatePipe) {
    this.route.paramMap.subscribe( paramMap => {
      this.id = paramMap.get('id');
    }, error => {
      console.log(error);
    });
  }

  async ngOnInit() {
    if ( this.id !== null ) {
      await this.getBook();
    } else {
      this.book = {};
    }
  }

  postBook() {
    this.booksService.postBook(this.book).subscribe(response => {
      console.log('success');
    }, error => {
      console.log(error);
    });
  }

  async getBook() {
    this.booksService.getBook(this.id).subscribe(response => {
      this.book = response;
      this.book.releaseDate = this.datePipe.transform(this.book.releaseDate, 'yyyy-MM-dd');
    }, error => {
      console.log(error);
    });
  }
}
