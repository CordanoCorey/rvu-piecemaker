import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SettingsComponent } from './settings.component';

const routes: Routes = [
  {
    path: '',
    component: SettingsComponent,
    data: { routeName: 'settings', routeLabel: 'Settings' },
    children: [
      { path: 'goals', loadChildren: () => import('../goals/goals.module').then(m => m.GoalsModule) },
      { path: 'services', loadChildren: () => import('../services/services.module').then(m => m.ServicesModule) },
      { path: 'users', loadChildren: () => import('../users/users.module').then(m => m.UsersModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {}
