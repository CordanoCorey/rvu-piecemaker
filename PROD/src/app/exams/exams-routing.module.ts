import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ExamsComponent } from './exams.component';
import { ExamGroupFormComponent } from './exam-group-form/exam-group-form.component';

const routes: Routes = [
  {
    path: '',
    component: ExamsComponent,
    data: { routeName: 'exams', routeLabel: 'Exams' },
    children: [
      {
        path: '',
        component: ExamGroupFormComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamsRoutingModule {}
