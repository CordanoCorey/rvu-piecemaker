import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, routeParamIdSelector, RouterActions, HttpActions, build, MessageSubscription, routeParamSelector, DateHelper } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Shift } from '../shifts/shifts.model';
import { shiftSelector, ShiftActions } from '../shifts/shifts.reducer';
import { CurrentUserActions, ServicesActions } from '../shared/actions';
import { Service } from '../shared/models';
import { servicesSelector, activeDateSelector, userNameSelector } from '../shared/selectors';
import { ServiceInfoComponent } from '../services/service-info/service-info.component';

@Component({
  selector: 'rvu-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.scss']
})
export class ShiftComponent extends SmartComponent implements OnInit {
  date: Date = new Date();
  date$: Observable<Date>;
  _shiftId = 0;
  serviceId = 0;
  serviceId$: Observable<number>;
  services$: Observable<Service[]>;
  shift: Shift = new Shift();
  shift$: Observable<Shift>;
  shiftId$: Observable<number>;
  userName$: Observable<string>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.date$ = activeDateSelector(store);
    this.serviceId$ = routeParamIdSelector(store, 'serviceId');
    this.services$ = servicesSelector(store);
    this.shift$ = shiftSelector(store);
    this.shiftId$ = routeParamIdSelector(store, 'shiftId');
    this.userName$ = userNameSelector(store);
  }

  get dateQuery(): string {
    return this.date ? `&date=${DateHelper.FormatDateSlashes(this.date)}` : '';
  }

  set shiftId(value: number) {
    if (value) {
      this.getShift(value);
    }
    this._shiftId = value;
  }

  get shiftId(): number {
    return this._shiftId;
  }

  get shiftUrl(): string {
    return `/shifts/${this.shiftId}`;
  }

  ngOnInit() {
    this.sync(['date', 'serviceId', 'shiftId']);
    this.onInit();
    this.getServices();
  }

  changeServiceId(e: number) {
    this.dispatch(RouterActions.navigate(`${this.shiftUrl}?serviceId=${e}${this.dateQuery}`));
  }

  getServices() {
    this.dispatch(HttpActions.get(`services`, ServicesActions.GET));
  }

  getShift(id: number) {
    this.dispatch(HttpActions.get(`shifts/${id}`, ShiftActions.GET));
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

  openServiceInfo() {
    this.openDialog(ServiceInfoComponent, {
      width: '600px'
    });
  }
}
