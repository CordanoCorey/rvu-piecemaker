import { NgModule } from '@angular/core';

import { ExamsRoutingModule } from './exams-routing.module';
import { ExamsComponent } from './exams.component';
import { CompletedExamsComponent } from './completed-exams/completed-exams.component';
import { ExamTypesModule } from '../exam-types/exam-types.module';
import { ExamModule } from '../exam/exam.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ExamsComponent, CompletedExamsComponent],
  imports: [SharedModule, ExamsRoutingModule, ExamTypesModule, ExamModule],
  exports: [ExamTypesModule, CompletedExamsComponent]
})
export class ExamsModule {}
