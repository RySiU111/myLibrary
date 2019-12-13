import { NgModule } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatCardModule } from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {TextFieldModule} from '@angular/cdk/text-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  imports: [
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    TextFieldModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  exports: [
    NgbModule,
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    TextFieldModule,
    MatDatepickerModule,
    MatNativeDateModule
  ]
})
export class AppMaterialsModule { }
