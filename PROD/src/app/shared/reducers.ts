import { build, Token, StorageActions, Action } from '@caiu/library';

import { CurrentUserActions, TabsActions, ServicesActions, ExamGroupsActions } from './actions';
import { CurrentUser, Tabs, ExamGroups, Services } from './models';

export function currentUserReducer(state: CurrentUser = new CurrentUser(), action: Action): CurrentUser {
  switch (action.type) {
    case StorageActions.INIT_STORE:
      return CurrentUser.Build(action.payload.localStore ? action.payload.localStore.currentUser : {});

    case CurrentUserActions.LOGIN:
      const token = build(Token, {
        access_token: action.payload.access_token,
        expires_in: action.payload.expires_in
      });

      return build(CurrentUser, state, action.payload.user as CurrentUser, {
        token,
        role: action.payload.role
      });

    case CurrentUserActions.LOGOUT:
      return build(CurrentUser, { token: new Token() });

    default:
      return state;
  }
}

export function servicesReducer(state: Services = new Services(), action: Action): Services {
  switch (action.type) {
    case ServicesActions.GET:
      return state.update(action.payload);
    default:
      return state;
  }
}

export function tabsReducer(state: Tabs = new Tabs(), action: Action): Tabs {
  switch (action.type) {
    case TabsActions.SET_ACTIVE:
      return build(Tabs, { items: action.payload });
    default:
      return state;
  }
}

export function examGroupsReducer(state: ExamGroups = new ExamGroups(), action: Action): ExamGroups {
  switch (action.type) {
    case ExamGroupsActions.GET:
      return state.update(action.payload);
    default:
      return state;
  }
}
