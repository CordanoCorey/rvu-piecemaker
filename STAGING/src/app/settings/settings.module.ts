import { NgModule } from '@angular/core';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './settings.component';
import { UserFormComponent } from './user-form/user-form.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [SettingsComponent, UserFormComponent],
  imports: [SharedModule, SettingsRoutingModule]
})
export class SettingsModule {}
