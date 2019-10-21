import { NgModule } from '@angular/core';
import { TimeModule } from '@caiu/library';

import { ShiftsRoutingModule } from './shifts-routing.module';
import { ShiftsComponent } from './shifts.component';
import { ShiftFormComponent } from './shift-form/shift-form.component';
import { ShiftTypeFormComponent } from './shift-type-form/shift-type-form.component';
import { ExamTypesModule } from '../exam-types/exam-types.module';
import { SharedModule } from '../shared/shared.module';
import { ShiftTypesComponent } from './shift-types/shift-types.component';
import { ShiftModule } from '../shift/shift.module';
import { ScheduleModule } from '../schedule/schedule.module';

@NgModule({
  declarations: [ShiftsComponent, ShiftFormComponent, ShiftTypeFormComponent, ShiftTypesComponent],
  imports: [SharedModule, ShiftsRoutingModule, ExamTypesModule, TimeModule, ScheduleModule, ShiftModule]
})
export class ShiftsModule {}
