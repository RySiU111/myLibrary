import { Component, OnInit } from '@angular/core';
import { BookService, Book } from '../services/book.service';
import { Params, ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-book-detailed',
  templateUrl: './book-detailed.component.html',
  styleUrls: ['./book-detailed.component.css']
})
export class BookDetailedComponent implements OnInit {

  book: Book;
  id: number;
  breakpoint = 991;
  width: number;

  constructor(
    private bookService: BookService,
    private route: ActivatedRoute,
    private router: Router,
    private appService: AppService) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params: Params) => {
      this.id = params.get('id');
    }, error => {
      console.log(error);
    });

    // tslint:disable-next-line: triple-equals
    if (isNaN(this.id) || (this.id == 0)) {
      this.router.navigate(['not-found']);
    } else {
      this.getBook(this.id);
    }
  }

  getBook(id: number) {
    this.bookService.getBook(id).subscribe(response => {
      this.book = response;
      this.book.releaseDate = this.appService.setDateWithTimeZone(this.book.releaseDate);
    }, error => {
      console.log(error);
    });
  }

 isCollapsed() {
   this.width = window.innerWidth;
   return this.width <= this.breakpoint;
 }
}
