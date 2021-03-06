import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ShiftsComponent } from './shifts.component';

const routes: Routes = [
  {
    path: '',
    component: ShiftsComponent,
    data: { routeName: 'shifts', routeLabel: 'Shifts' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShiftsRoutingModule {}
