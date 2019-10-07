import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticatedGuard } from '@caiu/library';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
      {
        path: 'login',
        loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
      },
      {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
        // canActivate: [AuthenticatedGuard]
      },
      {
        path: 'reset-password',
        loadChildren: () => import('./reset-password/reset-password.module').then(m => m.ResetPasswordModule)
      },
      {
        path: 'signup',
        loadChildren: () => import('./signup/signup.module').then(m => m.SignupModule)
      },
      {
        path: 'shifts/:shiftId',
        loadChildren: () => import('./shift/shift.module').then(m => m.ShiftModule)
      },
      {
        path: 'shifts',
        loadChildren: () => import('./shifts/shifts.module').then(m => m.ShiftsModule)
      },
      {
        path: 'exams',
        loadChildren: () => import('./exams/exams.module').then(m => m.ExamsModule)
      },
      {
        path: 'settings',
        loadChildren: () => import('./settings/settings.module').then(m => m.SettingsModule)
      },
      {
        path: 'search',
        loadChildren: () => import('./search/search.module').then(m => m.SearchModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthenticatedGuard]
})
export class AppRoutingModule {}
