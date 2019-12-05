import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule
  ],
  exports: [
    BrowserAnimationsModule,
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule
  ]
})
export class AppMaterialsModule { }
