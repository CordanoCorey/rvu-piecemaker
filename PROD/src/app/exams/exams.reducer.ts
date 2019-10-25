import { Action, routeParamIdSelector, DateHelper, toArray } from '@caiu/library';
import { Store, select } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Exams, Exam } from './exams.model';
import { ShiftActions } from '../shifts/shifts.reducer';
import { activeDateSelector, userIdSelector } from '../shared/selectors';

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
    case ExamsActions.POST:
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
  // return combineLatest(examsSelector(store), routeParamIdSelector(store, 'shiftId'), (exams, shiftId) => exams.asArray.filter(x => x.shiftId === shiftId));
  return combineLatest(examsSelector(store), activeDateSelector(store), userIdSelector(store), (exams, date, userId) =>
    exams.asArray.filter(x => x.userId === userId && DateHelper.IsSameDay(x.startTime, date))
  );
}

export function examsByDateSelector(store: Store<any>): Observable<{ [key: string]: Exam[] }> {
  return examsSelector(store).pipe(
    map(x =>
      x.asArray.reduce((acc, y) => {
        const key = DateHelper.FormatDateSlashes(y.startTime);
        const value = acc[key] && Array.isArray(acc[key]) ? [...acc[key], y] : [y];
        return Object.assign({}, acc, { [key]: value });
      }, {})
    )
  );
}

export function rvuTotalByDateSelector(store: Store<any>): Observable<{ [key: string]: number }> {
  return examsByDateSelector(store).pipe(
    map(x => {
      return Object.keys(x).reduce((acc, key) => {
        return Object.assign({}, acc, {
          [key]: toArray(x[key]).reduce((sum, exam) => {
            return sum + exam.rvuTotal;
          }, 0)
        });
      }, {});
    })
  );
}
