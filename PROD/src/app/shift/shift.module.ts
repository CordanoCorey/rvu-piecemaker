import { NgModule } from '@angular/core';

import { ShiftRoutingModule } from './shift-routing.module';
import { ShiftComponent } from './shift.component';
import { ShiftProgressComponent } from './shift-progress/shift-progress.component';
import { ShiftOverviewComponent } from './shift-overview/shift-overview.component';
import { ShiftPreviewComponent } from './shift-preview/shift-preview.component';
import { ShiftRecapComponent } from './shift-recap/shift-recap.component';
import { ExamsModule } from '../exams/exams.module';
import { ServicesModule } from '../services/services.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ShiftComponent, ShiftOverviewComponent, ShiftPreviewComponent, ShiftProgressComponent, ShiftRecapComponent],
  imports: [SharedModule, ShiftRoutingModule, ExamsModule, ServicesModule],
  exports: [ShiftOverviewComponent]
})
export class ShiftModule {}
