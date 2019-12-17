import { Component, OnInit, Input } from '@angular/core';
import { BookService } from '../services/book.service';
import { Router } from '@angular/router';

interface Book {
  title: string;
  description: string;
  releaseDate: Date;
}

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  book: Book = { title: '', description: '', releaseDate: null };

  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit() {
  }

  save() {
    this.bookService.postBook(this.book).subscribe(response => {
      console.log(response);
      this.router.navigate(['books']);
    }, error => {
      console.log(error);
    });
  }
}
