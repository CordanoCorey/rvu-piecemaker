import { NgModule } from '@angular/core';

import { ExamTypesComponent } from './exam-types.component';
import { SharedModule } from '../shared/shared.module';
import { ExamTypeFormComponent } from './exam-type-form/exam-type-form.component';

@NgModule({
  declarations: [ExamTypesComponent, ExamTypeFormComponent],
  imports: [SharedModule],
  exports: [ExamTypesComponent],
  entryComponents: [ExamTypeFormComponent]
})
export class ExamTypesModule {}
