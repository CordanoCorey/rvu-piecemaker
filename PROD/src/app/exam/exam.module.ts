import { NgModule } from '@angular/core';

import { ExamRoutingModule } from './exam-routing.module';
import { ExamFormComponent } from './exam-form/exam-form.component';
import { SharedModule } from '../shared/shared.module';
import { ExamComponent } from './exam.component';

@NgModule({
  declarations: [ExamFormComponent, ExamComponent],
  imports: [SharedModule, ExamRoutingModule],
  exports: [ExamFormComponent],
  entryComponents: [ExamFormComponent]
})
export class ExamModule {}
