import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule
  ],
  exports: [
    BrowserAnimationsModule,
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule
  ]
})
export class AppMaterialsModule { }
