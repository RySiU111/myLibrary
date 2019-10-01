import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

constructor(private http: HttpClient) { }

baseUrl = 'http://localhost:5000/api';
localhost = 'http://localhost:4200';

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

searchBook(search: string){
  return this.http.get(this.baseUrl + '/books/searchBook/' + search.toLowerCase().replace(' ', ''));
}

}
