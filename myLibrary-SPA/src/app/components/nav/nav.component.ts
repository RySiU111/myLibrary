import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  background = 'primary';
  links = [{ Name: 'Books', Url: '#'},
    { Name: 'Authors', Url: '#'},
    { Name: 'Other', Url: '#'}];
  activeLink = this.links[0];

  constructor() { }

  ngOnInit() {
  }

}
