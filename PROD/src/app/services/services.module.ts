import { NgModule } from '@angular/core';

import { ServicesRoutingModule } from './services-routing.module';
import { ServicesComponent } from './services.component';
import { ServiceInfoComponent } from './service-info/service-info.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ServicesComponent, ServiceInfoComponent],
  imports: [SharedModule, ServicesRoutingModule],
  entryComponents: [ServiceInfoComponent]
})
export class ServicesModule {}
