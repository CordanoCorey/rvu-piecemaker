import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { RouterActions, Action, HttpActions } from '@caiu/library';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { activeShiftTimestampSelector, activeShiftIdSelector, ShiftsActions } from './shifts.reducer';
import { CurrentUserActions } from '../shared/actions';
import { redirectToSelector } from '../shared/selectors';

@Injectable()
export class ShiftsEffects {
  /**
   * Get user shifts upon successful login.
   */
  @Effect() onLoginSuccess: Observable<Action> = this.actions$.pipe(
    ofType(CurrentUserActions.LOGIN),
    map(action => HttpActions.get(`shifts/user`, ShiftsActions.INIT))
  );

  /**
   * Navigate to root url upon successful login.
   */
  // @Effect() onShiftsInit: Observable<Action> = this.actions$.pipe(
  //   ofType(ShiftsActions.INIT),
  //   map(action => this.redirectAfterLogin())
  // );

  activeShiftId = 0;
  activeShiftId$: Observable<number>;
  activeShiftTimestamp = 0;
  activeShiftTimestamp$: Observable<number>;
  redirectTo = '';
  redirectTo$: Observable<string>;

  constructor(private actions$: Actions, public store: Store<any>) {
    this.redirectTo$ = redirectToSelector(store);
    this.redirectTo$.subscribe(x => {
      this.redirectTo = x;
    });
    this.activeShiftId$ = activeShiftIdSelector(store);
    this.activeShiftId$.subscribe(x => {
      this.activeShiftId = x;
    });
    this.activeShiftTimestamp$ = activeShiftTimestampSelector(store);
    this.activeShiftTimestamp$.subscribe(x => {
      this.activeShiftTimestamp = x;
    });
  }

  redirectAfterLogin(): Action {
    // const url = this.activeShiftId ? `/shifts/${this.activeShiftId}` : this.activeShiftTimestamp ? `/shifts/0?timestamp=${this.activeShiftTimestamp}` : this.redirectTo;
    const url = '/dashboard';
    return RouterActions.navigate(url);
  }
}
