import { NgModule } from '@angular/core';
import { EditorModule } from '@caiu/library';

import { ServicesRoutingModule } from './services-routing.module';
import { ServicesComponent } from './services.component';
import { ServiceInfoComponent } from './service-info/service-info.component';
import { ServiceFormComponent } from './service-form/service-form.component';
import { ExamTypesModule } from '../exam-types/exam-types.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ServicesComponent, ServiceInfoComponent, ServiceFormComponent],
  imports: [SharedModule, ServicesRoutingModule, EditorModule, ExamTypesModule],
  entryComponents: [ServiceInfoComponent]
})
export class ServicesModule {}
