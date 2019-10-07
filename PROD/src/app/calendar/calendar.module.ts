import { NgModule } from '@angular/core';
import { CalendarModule as MyCalendarModule } from '@caiu/library';

import { CalendarComponent } from './calendar.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [CalendarComponent],
  exports: [CalendarComponent],
  imports: [SharedModule, MyCalendarModule]
})
export class CalendarModule {}
