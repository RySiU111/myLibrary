import { Component, OnInit, Input } from '@angular/core';
import { isNullOrUndefined } from 'util';

interface Book {
  title: string;
  description: string;
  releaseDate;
}

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  book: Book = { title: '', description: '', releaseDate: ''};

  constructor() { }

  ngOnInit() {
  }

}
