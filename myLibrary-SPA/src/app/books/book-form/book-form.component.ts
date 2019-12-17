import { Component, OnInit } from '@angular/core';
import { BookService } from '../services/book.service';
import { Router, ActivatedRoute, Params } from '@angular/router';

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
  id: number;

  constructor(private bookService: BookService, private router: Router, private route: ActivatedRoute) { }

  async ngOnInit() {
    this.route.paramMap.subscribe((params: Params) => {
      this.id = params.get('id');
    }, error => {
      console.log(error);
    });

    // tslint:disable-next-line: triple-equals
    if (isNaN(this.id) || (this.id == 0)) {
      this.router.navigate(['not-found']);
    } else if (this.id != null) {
      await this.getBookToEdit(this.id);
    }
  }

  save() {
    this.bookService.postBook(this.book).subscribe(response => {
      this.router.navigate(['books']);
    }, error => {
      console.log(error);
    });
  }

  async getBookToEdit(id: number) {
    this.bookService.getBook(this.id).subscribe(response => {
      this.book = response;
      this.book.releaseDate = this.bookService.setDateWithTimeZone(new Date(this.book.releaseDate));
    }, error => {
      console.log(error);
    });
  }
}
