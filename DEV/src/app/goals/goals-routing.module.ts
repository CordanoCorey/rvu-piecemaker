import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GoalsComponent } from './goals.component';

const routes: Routes = [
  {
    path: '',
    component: GoalsComponent,
    data: { routeName: 'goals', routeLabel: 'Goals' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GoalsRoutingModule {}
