import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

export interface Book {
  title: string;
  description: string;
  releaseDate: Date;
}

@Injectable()
export class BookService {
  baseUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<any> {
    return this.http.get(this.baseUrl + '/books');
  }

  getBook(id: any): Observable<any> {
    return this.http.get(this.baseUrl + '/books/' + id);
  }

  postBook(model: any) {
    return this.http.post(this.baseUrl + '/books/', model);
  }

  deleteBook(id: any) {
    return this.http.delete(this.baseUrl + '/books/' + id);
  }

  searchBook(search: string) {
    return this.http.get(this.baseUrl + '/books/searchBook/' + search.toLowerCase().replace(' ', ''));
  }
}
