import { Action, compareStrings } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ExamTypes, ExamType } from './exam-types.model';

export class ExamTypesActions {
  static GET = '[Exam Types] GET';
  static POST = '[Exam Types] POST';
}

export class ExamTypeActions {
  static DELETE = '[Exam Type] DELETE';
  static PUT = '[Exam Type] PUT';
}

export function examTypesReducer(state: ExamTypes = new ExamTypes(), action: Action): ExamTypes {
  switch (action.type) {
    case ExamTypesActions.GET:
      return state.update(action.payload);

    case ExamTypesActions.POST:
      return state;

    case ExamTypeActions.PUT:
      return state;

    case ExamTypeActions.DELETE:
      return state;

    default:
      return state;
  }
}

export function examTypesSelector(store: Store<any>): Observable<ExamType[]> {
  return store.select('examTypes').pipe(map(x => x.asArray.sort((a, b) => compareStrings(`${a.modalityName}-${a.name}`, `${b.modalityName}-${b.name}`))));
}
