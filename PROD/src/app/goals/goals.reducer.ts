import { Action } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

import { Goals, Goal } from './goals.model';
import { rvuRateSelector } from '../shared/selectors';
import { rvuTotalByDateSelector } from '../exams/exams.reducer';

export class GoalsActions {
  static GET = '[Goals] GET';
  static INIT = '[Goals] INIT';
}

export function goalsReducer(state: Goals = new Goals(), action: Action): Goals {
  switch (action.type) {
    case GoalsActions.INIT:
      return state.update(action.payload);

    default:
      return state;
  }
}

export function goalsSelector(store: Store<any>): Observable<Goals> {
  return store.select('goals');
}

export function goalSelector(store: Store<any>): Observable<Goal> {
  return goalsSelector(store).pipe(map(x => x.asArray.find(y => y.yearId === 1))); // TODO: remove hard-coded yearId
}

export function dollarGoalSelector(store: Store<any>): Observable<number> {
  return goalSelector(store).pipe(
    map(x => x.dollarAmount),
    distinctUntilChanged()
  );
}

export function rvuGoalSelector(store: Store<any>): Observable<number> {
  return combineLatest(dollarGoalSelector(store), rvuRateSelector(store), (dollars, rvuRate) => {
    return dollars * rvuRate;
  });
}

export function rvuPerHourGoalSelector(store: Store<any>): Observable<number> {
  return combineLatest(dollarGoalSelector(store), rvuRateSelector(store), (dollars, rvuRate) => {
    return dollars * rvuRate;
  });
}

export function rvuGoalPerHourSelector(store: Store<any>): Observable<number> {
  return goalSelector(store).pipe(
    map(x => (x ? x.rvuTotalPerHourRemaining : 0)),
    distinctUntilChanged()
  );
}

export function nonzeroRvuTotalsSelector(store: Store<any>): Observable<number[]> {
  return rvuTotalByDateSelector(store).pipe(
    map(x =>
      Object.keys(x)
        .map(key => x[key])
        .filter(y => y > 0)
    )
  );
}
