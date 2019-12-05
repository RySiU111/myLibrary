import { Component, OnInit } from '@angular/core';
import { BookServiceService } from 'src/app/_services/book-service.service';

@Component({
  selector: 'app-book-dashboard',
  templateUrl: './book-dashboard.component.html',
  styleUrls: ['./book-dashboard.component.css']
})
export class BookDashboardComponent implements OnInit {
  books = [];

  constructor(private service: BookServiceService) { }

  ngOnInit() {
    this.getBooks();
  }

  getBooks() {
    this.service.getBooks().subscribe(response => {
      this.books = response;
    }, error => {
      console.log(error);
    });
  }

}
