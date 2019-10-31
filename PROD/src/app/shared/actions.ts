import { Action } from '@caiu/library';

import { Tab } from './models';

export class CurrentUserActions {
  static LOGIN = '[CurrentUser] Login';
  static LOGIN_ERROR = '[CurrentUser] Login Error';
  static LOGOUT = '[CurrentUser] Logout';
  static GENERATE_PASSWORD_RESET_CODE = '[CurrentUser] Reset Password Code';
  static RESET_PASSWORD = '[CurrentUser] Reset Password';
  static RESET_PASSWORD_ERROR = '[CurrentUser] Reset Password Error';
  static SIGNUP = '[CurrentUser] Signup';
  static ALL = [CurrentUserActions.LOGIN, CurrentUserActions.LOGOUT, CurrentUserActions.RESET_PASSWORD];

  static logout(): Action {
    return {
      type: CurrentUserActions.LOGOUT
    };
  }
}

export class TabsActions {
  static SET_ACTIVE = '[Tabs] SET ACTIVE';

  static activate(payload: Tab[]): Action {
    return {
      type: TabsActions.SET_ACTIVE,
      payload
    };
  }
}
