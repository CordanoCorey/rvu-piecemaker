import { Action } from '@caiu/library';

import { ExamGroups } from './exam-groups.model';

export class ExamGroupsActions {
  static GET = '[ExamGroups] GET';
}

export function examGroupsReducer(state: ExamGroups = new ExamGroups(), action: Action): ExamGroups {
  switch (action.type) {
    case ExamGroupsActions.GET:
      return state.update(action.payload);
    default:
      return state;
  }
}
