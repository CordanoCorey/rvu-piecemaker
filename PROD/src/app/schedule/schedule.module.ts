import { NgModule } from '@angular/core';

import { ScheduleComponent } from './schedule.component';
import { SharedModule } from '../shared/shared.module';
import { CalendarModule } from '../shared/calendar/calendar.module';

@NgModule({
  declarations: [ScheduleComponent],
  imports: [SharedModule, CalendarModule],
  exports: [ScheduleComponent]
})
export class ScheduleModule {}
