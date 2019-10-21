import { NgModule } from '@angular/core';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { GoalsModule } from '../goals/goals.module';
import { ScheduleModule } from '../schedule/schedule.module';
import { ShiftModule } from '../shift/shift.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [DashboardComponent],
  imports: [SharedModule, DashboardRoutingModule, ScheduleModule, ShiftModule, GoalsModule]
})
export class DashboardModule {}
