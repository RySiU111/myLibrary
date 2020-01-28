import { Component, OnInit } from '@angular/core';
import { BookService, Book } from '../services/book.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  book: Book = { id: 0, title: '', description: '', releaseDate: null, photoUrl: '', authorId: 0, author: null };
  id: number;

  constructor(
    private bookService: BookService,
    private router: Router,
    private route: ActivatedRoute,
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
    } else if (this.id != null) {
      this.getBookToEdit(this.id);
    }
  }

  save() {
    this.bookService.postBook(this.book).subscribe(response => {
      this.router.navigate(['books']);
    }, error => {
      console.log(error);
    });
  }

  getBookToEdit(id: number) {
    this.bookService.getBook(this.id).subscribe(response => {
      this.book = response;
      this.book.releaseDate = this.appService.setDateWithTimeZone(this.book.releaseDate);
    }, error => {
      console.log(error);
    });
  }
}
