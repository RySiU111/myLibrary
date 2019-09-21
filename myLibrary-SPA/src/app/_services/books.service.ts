import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

constructor(private http: HttpClient) { }

baseUrl = 'http://localhost:5000/api';

getBooks(): Observable<any> {
  return this.http.get(this.baseUrl + '/books');
}

getBook(id: any): Observable<any> {
  return this.http.get(this.baseUrl + '/books/' + id);
}

postBook(model: any): Observable<any> {
  return this.http.post(this.baseUrl, model);
}

deleteBook(id: number) {

}

}
