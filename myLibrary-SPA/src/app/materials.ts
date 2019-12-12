import { NgModule } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@NgModule({
  imports: [
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  exports: [
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule,
    MatProgressSpinnerModule
  ]
})
export class AppMaterialsModule { }
