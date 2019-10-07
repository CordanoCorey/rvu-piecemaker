import { NgModule } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';

import { GoalsRoutingModule } from './goals-routing.module';
import { GoalsComponent } from './goals.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [GoalsComponent],
  imports: [SharedModule, GoalsRoutingModule, MatGridListModule],
  exports: [GoalsComponent]
})
export class GoalsModule {}
