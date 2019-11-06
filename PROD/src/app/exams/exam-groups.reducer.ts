import { Action, routeParamIdSelector, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { ExamGroups, ExamGroup } from './exam-groups.model';

export class ExamGroupsActions {
  static GET = '[ExamGroups] GET';
  static POST = '[ExamGroups] POST';
  static POST_ERROR = '[ExamGroups] POST ERROR';
}

export class ExamGroupActions {
  static DELETE = '[ExamGroups] DELETE';
  static DELETE_ERROR = '[ExamGroups] DELETE ERROR';
  static PUT = '[ExamGroups] PUT';
  static PUT_ERROR = '[ExamGroups] PUT ERROR';
}

export function examGroupsReducer(state: ExamGroups = new ExamGroups(), action: Action): ExamGroups {
  switch (action.type) {
    case ExamGroupsActions.GET:
    case ExamGroupsActions.POST:
    case ExamGroupActions.PUT:
      return state.update(action.payload);

    case ExamGroupActions.DELETE:
      return build(ExamGroups, state.delete(action.payload));

    default:
      return state;
  }
}

export function examGroupsSelector(store: Store<any>): Observable<ExamGroups> {
  return store.select('examGroups');
}

export function userExamGroupsSelector(store: Store<any>): Observable<ExamGroup[]> {
  return examGroupsSelector(store).pipe(map(x => x.asArray));
}

export function examGroupSelector(store: Store<any>): Observable<ExamGroup> {
  return combineLatest(examGroupsSelector(store), routeParamIdSelector(store, 'examGroupId'), (examGroups, id) => {
    return build(ExamGroup, examGroups.asArray.find(x => x.id === id));
  });
}
