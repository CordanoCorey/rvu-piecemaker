import { NgModule } from '@angular/core';

import { ExamsRoutingModule } from './exams-routing.module';
import { ExamsComponent } from './exams.component';
import { CompletedExamsComponent } from './completed-exams/completed-exams.component';
import { ExamTypesModule } from '../exam-types/exam-types.module';
import { ExamModule } from '../exam/exam.module';
import { SharedModule } from '../shared/shared.module';
import { ExamGroupFormComponent } from './exam-group-form/exam-group-form.component';

@NgModule({
  declarations: [ExamsComponent, CompletedExamsComponent, ExamGroupFormComponent],
  imports: [SharedModule, ExamsRoutingModule, ExamTypesModule, ExamModule],
  exports: [ExamTypesModule, CompletedExamsComponent]
})
export class ExamsModule {}
