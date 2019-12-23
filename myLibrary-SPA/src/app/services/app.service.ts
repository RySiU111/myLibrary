import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor() { }

  setDateWithTimeZone(date: any): Date {
    date = new Date(date);
    const timeZone = date.getTimezoneOffset() / -60;
    date.setHours(date.getHours() + timeZone);
    return date;
  }
}
