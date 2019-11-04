import { Component, OnInit, Input } from '@angular/core';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Shift } from '../../shifts/shifts.model';
import { ShiftActions } from '../../shifts/shifts.reducer';
import { currentTimeSelector } from 'src/app/shared/selectors';

@Component({
  selector: 'rvu-shift-progress',
  templateUrl: './shift-progress.component.html',
  styleUrls: ['./shift-progress.component.scss']
})
export class ShiftProgressComponent extends SmartComponent implements OnInit {
  @Input() rvuGoal = 0;
  @Input() shift: Shift = new Shift();
  currentTime: Date = new Date();
  currentTime$: Observable<Date>;
  _shiftId = 0;

  constructor(public store: Store<any>) {
    super(store);
    this.currentTime$ = currentTimeSelector(store);
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
    return Math.min(100, (this.shift.rvuCount / this.rvuGoal) * 100);
  }

  get percentFilledTime(): number {
    const start = this.startTimestamp;
    const current = this.currentTime.getTime();
    const end = this.endTimestamp;
    return Math.min(100, ((current - start) / (end - start)) * 100);
  }

  get startTimestamp(): number {
    return this.shift ? (this.shift.startTime && this.shift.startTime.getTime ? this.shift.startTime.getTime() : 0) : 0;
  }

  get endTimestamp(): number {
    return this.shift ? (this.shift.endTime && this.shift.endTime.getTime ? this.shift.endTime.getTime() : 0) : 0;
  }

  ngOnInit() {
    this.sync(['currentTime']);
  }

  getShift(shiftId: number) {
    this.dispatch(HttpActions.get(`shifts/${shiftId}`, ShiftActions.GET));
  }
}
