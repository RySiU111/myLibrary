import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './routes';
import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { AppMaterialsModule } from './materials';
import { BookDashboardComponent } from './components/book-dashboard/book-dashboard.component';
import { BookServiceService } from './_services/book-service.service';
import { HttpClientModule } from '@angular/common/http';
import { BookCardComponent } from './components/book-card/book-card.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BookDashboardComponent,
    BookCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppMaterialsModule,
    HttpClientModule
  ],
  providers: [BookServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
