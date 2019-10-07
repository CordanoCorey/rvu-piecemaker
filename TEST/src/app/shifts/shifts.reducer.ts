import { Action, routeParamIdSelector, build, truthy } from '@caiu/library';
import { Store } from '@ngrx/store';
import { combineLatest, Observable } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

import { Shifts, Shift } from './shifts.model';
import { Exams, Exam } from '../exams/exams.model';
import { userIdSelector } from '../shared/selectors';

export class ShiftsActions {
  static INIT = '[Shifts] INIT';
  static GET = '[Shifts] GET';
  static POST = '[Shifts] POST';
}

export class ShiftActions {
  static DELETE = '[Shift] DELETE';
  static GET = '[Shift] GET';
  static PUT = '[Shift] PUT';
}

export function shiftsReducer(state: Shifts = new Shifts(), action: Action): Shifts {
  switch (action.type) {
    case ShiftsActions.INIT:
      return state.update(action.payload);

    case ShiftActions.GET:
      return state.update(action.payload);

    default:
      return state;
  }
}

export function shiftsSelector(store: Store<any>): Observable<Shifts> {
  return store.select('shifts');
}

export function shiftIdSelector(store: Store<any>): Observable<number> {
  return combineLatest(routeParamIdSelector(store, 'shiftId'), shiftsSelector(store), (shiftId: number, shifts: Shifts) => shiftId || shifts.activeShiftTimestamp);
}

export function activeShiftIdSelector(store: Store<any>): Observable<number> {
  return shiftsSelector(store).pipe(
    map(x => x.activeShiftId),
    distinctUntilChanged()
  );
}

export function lastShiftIdSelector(store: Store<any>): Observable<number> {
  return shiftsSelector(store).pipe(
    map(x => x.lastShiftId),
    distinctUntilChanged()
  );
}

export function nextShiftIdSelector(store: Store<any>): Observable<number> {
  return shiftsSelector(store).pipe(
    map(x => x.nextShiftId),
    distinctUntilChanged()
  );
}

export function activeShiftSelector(store: Store<any>): Observable<Shift> {
  return combineLatest(shiftsSelector(store), activeShiftIdSelector(store), (shifts: Shifts, id: number) => (id ? shifts.get(id) : null));
}

export function lastShiftSelector(store: Store<any>): Observable<Shift> {
  return combineLatest(shiftsSelector(store), lastShiftIdSelector(store), (shifts: Shifts, id: number) => (id ? shifts.get(id) : null));
}

export function nextShiftSelector(store: Store<any>): Observable<Shift> {
  return combineLatest(shiftsSelector(store), nextShiftIdSelector(store), (shifts: Shifts, id: number) => (id ? shifts.get(id) : null));
}

export function shiftSelector(store: Store<any>): Observable<Shift> {
  return combineLatest(shiftsSelector(store), activeShiftTimestampSelector(store), store.select('exams'), (shifts: Shifts, id: number, exams: Exams) => {
    const s = build(Shift, shifts.get(id));
    return Object.assign(s, {
      exams: exams.asArray.filter(x => x.shiftId === s.id).map(y => Exam.Build(y))
    });
  });
}

export function shiftStatusSelector(store: Store<any>): Observable<string> {
  return combineLatest(activeShiftSelector(store), lastShiftSelector(store), nextShiftSelector(store), (activeShift, lastShift, nextShift) => {
    return truthy(activeShift) ? 'ACTIVE' : truthy(lastShift) ? 'ENDED' : truthy(nextShift) ? 'UPCOMING' : 'PENDING';
  });
}

export function activeShiftTimestampSelector(store: Store<any>): Observable<number> {
  return shiftsSelector(store).pipe(
    map(x => x.activeShiftTimestamp),
    distinctUntilChanged()
  );
}

export function userShiftsSelector(store: Store<any>): Observable<Shift[]> {
  return combineLatest(shiftsSelector(store), userIdSelector(store), (shifts, userId) => shifts.asArray.filter(y => y.userId === userId));
}

export function rvuTotalForYearSelector(store: Store<any>): Observable<number> {
  return userShiftsSelector(store).pipe(map(x => x.reduce((acc, y) => acc + y.rvuTotal, 0)));
}
