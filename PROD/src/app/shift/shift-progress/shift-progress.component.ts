import { Component, OnInit, Input } from '@angular/core';
import { SmartComponent, HttpActions, routeParamSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Shift } from '../../shifts/shifts.model';
import { ShiftActions, shiftRvuTotalSelector } from '../../shifts/shifts.reducer';
import { currentTimeSelector } from 'src/app/shared/selectors';

@Component({
  selector: 'rvu-shift-progress',
  templateUrl: './shift-progress.component.html',
  styleUrls: ['./shift-progress.component.scss']
})
export class ShiftProgressComponent extends SmartComponent implements OnInit {
  @Input() rvuGoal = 60;
  @Input() shift: Shift = new Shift();
  currentTime: Date = new Date();
  currentTime$: Observable<Date>;
  shiftDate: Date = new Date();
  shiftDate$: Observable<Date>;
  shiftRvuTotal = 0;
  shiftRvuTotal$: Observable<number>;
  _shiftId = 0;

  constructor(public store: Store<any>) {
    super(store);
    this.currentTime$ = currentTimeSelector(store);
    this.shiftDate$ = routeParamSelector(store, 'date');
    this.shiftRvuTotal$ = shiftRvuTotalSelector(store);
  }

  @Input()
  set shiftId(value: number) {
    if (value && this._shiftId !== value) {
      this.getShift(value);
    }
    this._shiftId = value;
  }

  get shiftId(): number {
    return this._shiftId;
  }

  get percentFilledRVU(): number {
    return Math.min(100, (this.shiftRvuTotal / this.rvuGoal) * 100);
  }

  get percentFilledTime(): number {
    const start = this.startTimestamp;
    const current = this.currentTime.getTime();
    const end = this.endTimestamp;
    return Math.min(100, ((current - start) / (end - start)) * 100);
  }

  get startTime(): Date {
    // return this.shift ? (this.shift.startTime && this.shift.startTime.getTime ? this.shift.startTime.getTime() : 0) : 0;
    const d = new Date(this.shiftDate);
    return new Date(d.getFullYear(), d.getMonth(), d.getDate(), 7, 30);
  }

  get endTime(): Date {
    // return this.shift ? (this.shift.endTime && this.shift.endTime.getTime ? this.shift.endTime.getTime() : 0) : 0;
    const d = new Date(this.shiftDate);
    return new Date(d.getFullYear(), d.getMonth(), d.getDate(), 16, 45);
  }

  get startTimestamp(): number {
    // return this.shift ? (this.shift.startTime && this.shift.startTime.getTime ? this.shift.startTime.getTime() : 0) : 0;
    return this.startTime.getTime();
  }

  get endTimestamp(): number {
    // return this.shift ? (this.shift.endTime && this.shift.endTime.getTime ? this.shift.endTime.getTime() : 0) : 0;
    return this.endTime.getTime();
  }

  ngOnInit() {
    this.sync(['currentTime', 'shiftDate', 'shiftRvuTotal']);
  }

  getShift(shiftId: number) {
    this.dispatch(HttpActions.get(`shifts/${shiftId}`, ShiftActions.GET));
  }
}
