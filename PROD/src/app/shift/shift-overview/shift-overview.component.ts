import { Component, OnInit, Input } from '@angular/core';
import { SmartComponent, routeParamIdSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { rvuGoalPerHourSelector } from '../../goals/goals.reducer';
import { Shift } from '../../shifts/shifts.model';
import { activeShiftIdSelector, shiftSelector, lastShiftSelector, nextShiftSelector } from '../../shifts/shifts.reducer';

@Component({
  selector: 'rvu-shift-overview',
  templateUrl: './shift-overview.component.html',
  styleUrls: ['./shift-overview.component.scss']
})
export class ShiftOverviewComponent extends SmartComponent implements OnInit {
  activeShiftId = 0;
  activeShiftId$: Observable<number>;
  lastShift$: Observable<Shift>;
  nextShift$: Observable<Shift>;
  rvuGoalPerHour$: Observable<number>;
  shift: Shift = new Shift();
  shift$: Observable<Shift>;
  shiftId = 0;
  shiftId$: Observable<number>;
  _rvuGoalPerHour = 0;

  constructor(public store: Store<any>) {
    super(store);
    this.shiftId$ = routeParamIdSelector(store, 'shiftId');
    this.activeShiftId$ = activeShiftIdSelector(store);
    this.lastShift$ = lastShiftSelector(store);
    this.nextShift$ = nextShiftSelector(store);
    this.rvuGoalPerHour$ = rvuGoalPerHourSelector(store);
    this.shift$ = shiftSelector(store);
  }

  get isActiveShift(): boolean {
    return this.activeShiftId === this.shiftId;
  }

  set rvuGoalPerHour(value: number) {
    this._rvuGoalPerHour = value;
  }

  get rvuGoalPerHour(): number {
    return this._rvuGoalPerHour;
  }

  get shiftRvuGoal(): number {
    // return parseFloat((Math.round(this.rvuGoalPerHour * this.shift.totalHours * 10) / 10).toFixed(1));
    // return Math.round(this.rvuGoalPerHour * this.shift.totalHours * 10) / 10;
    return 60;
  }

  ngOnInit() {
    this.sync(['activeShiftId', 'rvuGoalPerHour', 'shiftId']);
  }
}
