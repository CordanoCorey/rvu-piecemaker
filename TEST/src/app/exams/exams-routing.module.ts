import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamsComponent } from './exams.component';

const routes: Routes = [
  {
    path: '',
    component: ExamsComponent,
    data: { routeName: 'exams', routeLabel: 'Exams' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamsRoutingModule {}
