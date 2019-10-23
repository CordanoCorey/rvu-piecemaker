import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ServicesComponent } from './services.component';
import { ServiceFormComponent } from './service-form/service-form.component';

const routes: Routes = [
  {
    path: '',
    component: ServicesComponent,
    children: [{ path: ':serviceId', component: ServiceFormComponent }]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicesRoutingModule {}
