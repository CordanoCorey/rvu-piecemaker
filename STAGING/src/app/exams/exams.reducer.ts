import { Action, routeParamIdSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Exams, Exam } from './exams.model';
import { ShiftActions } from '../shifts/shifts.reducer';

export class ExamsActions {
  static GET = '[Exams] GET';
  static POST = '[Exams] POST';
  static POST_ERROR = '[Exams] POST ERROR';
}

export class ExamActions {
  static DELETE = '[Exams] DELETE';
  static PUT = '[Exams] PUT';
}

export function examsReducer(state: Exams = new Exams(), action: Action): Exams {
  switch (action.type) {
    case ExamsActions.GET:
      return state;

    case ExamsActions.POST:
      return state.update(action.payload);

    case ExamActions.PUT:
      return state.update(action.payload);

    case ExamActions.DELETE:
      return state.delete(action.payload);

    case ShiftActions.GET:
      return state.update(action.payload.exams);

    default:
      return state;
  }
}

export function examsSelector(store: Store<any>): Observable<Exams> {
  return store.select('exams');
}

export function completedExamsSelector(store: Store<any>): Observable<Exam[]> {
  return combineLatest(examsSelector(store), routeParamIdSelector(store, 'shiftId'), (exams, shiftId) => exams.asArray.filter(x => x.shiftId === shiftId));
}
