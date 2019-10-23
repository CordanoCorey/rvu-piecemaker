import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { RouterActions, Action } from '@caiu/library';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CurrentUserActions } from './actions';

@Injectable()
export class UserEffects {
  /**
   * Navigate to login page after logging out or after creating a new user.
   */
  @Effect() onLogout: Observable<Action> = this.actions$.pipe(
    ofType(CurrentUserActions.LOGOUT, CurrentUserActions.SIGNUP),
    map(action => RouterActions.navigate('/login'))
  );

  /**
   * Navigate to reset password after getting password reset code
   */
  @Effect() onGeneratePasswordResetCode: Observable<Action> = this.actions$.pipe(
    ofType(CurrentUserActions.GENERATE_PASSWORD_RESET_CODE),
    map((action: Action) => this.redirectToResetPassword(action.payload.passwordResetCode))
  );

  /**
   * Navigate to login after resetting password
   */
  @Effect() onResetPassword: Observable<Action> = this.actions$.pipe(
    ofType(CurrentUserActions.RESET_PASSWORD),
    map(action => RouterActions.navigate('/login'))
  );

  /**
   * Navigate to dashboard after login
   */
  @Effect() onLogin: Observable<Action> = this.actions$.pipe(
    ofType(CurrentUserActions.LOGIN),
    map(action => RouterActions.navigate('/dashboard'))
  );

  constructor(private actions$: Actions, public store: Store<any>) {}

  redirectToResetPassword(passwordResetCode: string): Action {
    return RouterActions.navigate(`/reset-password?code=${passwordResetCode}`);
  }
}
