import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { Action, HttpActions, StorageActions } from '@caiu/library';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GoalsActions } from './goals.reducer';
import { CurrentUserActions } from '../shared/actions';
import { CurrentUser } from '../shared/models';

@Injectable()
export class GoalsEffects {
  /**
   * Get user shifts upon successful login.
   */
  @Effect() onLoginSuccess: Observable<Action> = this.actions$.pipe(
    ofType(CurrentUserActions.LOGIN),
    map((action: Action) => this.fetchGoals(action.payload.user))
  );

  /**
   * Get user shifts upon successful login.
   */
  // @Effect() onInitStore: Observable<Action> = this.actions$.pipe(
  //   ofType(StorageActions.INIT_STORE),
  //   map((action: Action) => this.fetchGoals(action.payload.localStore.currentUser))
  // );

  constructor(private actions$: Actions) {}

  fetchGoals(user: CurrentUser): Action {
    return user.id ? HttpActions.get(`goals/current`, GoalsActions.INIT) : { type: 'NO ACTION' };
  }
}
