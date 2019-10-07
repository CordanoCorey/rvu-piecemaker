import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, SmartComponent, build, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';

import { Shift } from '../shifts.model';
import { Observable } from 'rxjs';
import { ShiftActions, shiftSelector, ShiftsActions } from '../shifts.reducer';
import { rvuRateSelector } from '../../shared/selectors';

@Component({
  selector: 'rvu-shift-form',
  templateUrl: './shift-form.component.html',
  styleUrls: ['./shift-form.component.scss']
})
export class ShiftFormComponent extends SmartComponent implements OnInit {
  @Control(Shift) form: FormGroup;
  rvuRate = 0;
  rvuRate$: Observable<number>;
  shift$: Observable<Shift>;
  shiftId$: Observable<number>;
  _shift: Shift = new Shift();
  _shiftId = 0;

  constructor(public store: Store<any>) {
    super(store);
    this.rvuRate$ = rvuRateSelector(store);
    this.shift$ = shiftSelector(store);
  }

  @Input()
  set shift(value: Shift) {
    this._shift = value;
  }

  get shift(): Shift {
    return this._shift;
  }

  set shiftId(value: number) {
    this._shiftId = value;
  }

  get shiftId(): number {
    return this._shiftId;
  }

  get valueOut(): Shift {
    return build(Shift, this.form.value, {
      id: this.shiftId,
      rvuRate: this.rvuRate
    });
  }

  ngOnInit() {
    this.sync(['rvuRate', 'shift']);
  }

  addShift(shift: Shift) {
    this.dispatch(HttpActions.post(`shifts`, shift, ShiftsActions.POST));
  }

  deleteShift(shift: Shift) {
    this.dispatch(HttpActions.delete(`shifts/${shift.id}`, shift.id, ShiftActions.DELETE));
  }

  getShift(shiftId: number) {
    this.dispatch(HttpActions.get(`shifts/${shiftId}`, ShiftActions.GET));
  }

  updateShift(shift: Shift) {
    this.dispatch(HttpActions.put(`shifts/${shift.id}`, shift, ShiftActions.PUT));
  }
}
