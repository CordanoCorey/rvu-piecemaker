import { Component, OnInit } from '@angular/core';
import { SmartComponent, RouterActions, HttpActions, build, MessageSubscription } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Service } from './services.model';
import { servicesSelector, ServicesActions, ServiceActions } from './services.reducer';
import { userIdSelector } from '../shared/selectors';

@Component({
  selector: 'rvu-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent extends SmartComponent implements OnInit {
  services$: Observable<Service[]>;
  _userId = 0;
  userId$: Observable<number>;
  messages = [
    build(MessageSubscription, {
      action: ServiceActions.PUT,
      channel: 'TOASTS',
      mapper: e => `Service saved successfully!`
    }),
    build(MessageSubscription, {
      action: ServiceActions.PUT_ERROR,
      channel: 'ERRORS',
      mapper: e => `Failed to save service.`
    })
  ];

  constructor(public store: Store<any>) {
    super(store);
    this.services$ = servicesSelector(store);
    this.userId$ = userIdSelector(store);
  }

  set userId(value: number) {
    this._userId = value;
    this.getServices();
  }

  get userId(): number {
    return this._userId;
  }

  ngOnInit() {
    this.sync(['userId']);
    this.onInit();
  }

  goToService(e: number) {
    this.dispatch(RouterActions.navigate(`/services/${e}`));
  }

  getServices() {
    this.dispatch(HttpActions.get(`services`, ServicesActions.GET));
  }
}
