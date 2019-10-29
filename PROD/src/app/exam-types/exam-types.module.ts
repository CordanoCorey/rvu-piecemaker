import { NgModule } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';

import { ExamTypesComponent } from './exam-types.component';
import { ExamTypeFormComponent } from './exam-type-form/exam-type-form.component';
import { ExamTypesControlComponent } from './exam-types-control/exam-types-control.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ExamTypesComponent, ExamTypeFormComponent, ExamTypesControlComponent],
  imports: [SharedModule, MatChipsModule],
  exports: [ExamTypesComponent, ExamTypesControlComponent],
  entryComponents: [ExamTypeFormComponent]
})
export class ExamTypesModule {}
