import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { SmartComponent, Control, build, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';

import { Service } from '../services.model';
import { Observable } from 'rxjs';
import { serviceSelector, ServiceActions } from '../services.reducer';

@Component({
  selector: 'rvu-service-form',
  templateUrl: './service-form.component.html',
  styleUrls: ['./service-form.component.scss']
})
export class ServiceFormComponent extends SmartComponent implements OnInit {
  @Control(Service) form: FormGroup;
  _service: Service = new Service();
  service$: Observable<Service>;

  constructor(public store: Store<any>) {
    super(store);
    this.service$ = serviceSelector(store);
  }

  set service(value: Service) {
    this._service = value;
    this.setValue(value);
  }

  get service(): Service {
    return this._service;
  }

  get valueOut(): Service {
    return build(Service, this.service, this.form.value, {
      doctorTypeId: 1
    });
  }

  ngOnInit() {
    this.sync(['service']);
  }

  onSave() {
    this.updateService(this.valueOut);
  }

  updateService(e: Service) {
    this.dispatch(HttpActions.put(`services/${e.id}`, e, ServiceActions.PUT));
  }
}
