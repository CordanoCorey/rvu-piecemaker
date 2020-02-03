import { NgModule } from '@angular/core';
import { MatNativeDateModule } from '@angular/material';
import { MatDatepickerModule } from '@angular/material/datepicker';

import { ReportsRoutingModule } from './reports-routing.module';
import { ReportsComponent } from './reports.component';
import { ExamsModule } from '../exams/exams.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [ReportsComponent],
  imports: [
    SharedModule,
    ReportsRoutingModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ExamsModule
  ],
  providers: [MatDatepickerModule]
})
export class ReportsModule { }
