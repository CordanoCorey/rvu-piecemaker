import { NgModule } from '@angular/core';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { CalendarModule } from '../calendar/calendar.module';
import { GoalsModule } from '../goals/goals.module';
import { ShiftModule } from '../shift/shift.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [DashboardComponent],
  imports: [SharedModule, DashboardRoutingModule, CalendarModule, ShiftModule, GoalsModule]
})
export class DashboardModule {}
