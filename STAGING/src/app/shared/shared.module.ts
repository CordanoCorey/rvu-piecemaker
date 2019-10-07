import { NgModule, ModuleWithProviders } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { LibraryModule, FormsModule } from '@caiu/library';

import { ContainerComponent } from './container/container.component';
import { HeaderComponent } from './header/header.component';
import { environment } from '../../environments/environment';
import { SidenavComponent } from './sidenav/sidenav.component';
import { ProgressBarComponent } from './progress-bar/progress-bar.component';

@NgModule({
  declarations: [ContainerComponent, HeaderComponent, ProgressBarComponent, SidenavComponent],
  imports: [FormsModule, LibraryModule, MatMenuModule, MatSnackBarModule, MatTableModule, RouterModule],
  exports: [FormsModule, LibraryModule, MatMenuModule, MatSnackBarModule, MatTableModule, ProgressBarComponent, RouterModule, ContainerComponent]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [{ provide: 'Environment', useValue: environment }]
    };
  }
}
