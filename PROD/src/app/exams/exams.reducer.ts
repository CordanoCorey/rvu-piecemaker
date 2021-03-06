import { Action, DateHelper, toArray } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Exams, Exam } from './exams.model';
import { ShiftActions } from '../shifts/shifts.reducer';
import { activeDateRangeSelector, userIdSelector } from '../shared/selectors';

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

export function userExamsSelector(store: Store<any>): Observable<Exam[]> {
  return combineLatest(examsSelector(store), userIdSelector(store), (exams, userId) => exams.asArray.filter(x => x.userId === userId));
}

export function completedExamsSelector(store: Store<any>): Observable<Exam[]> {
  return combineLatest(examsSelector(store), activeDateRangeSelector(store), userIdSelector(store), (exams, dateRange, userId) =>
    exams.asArray.filter(x => x.userId === userId
      && (dateRange.endDate && !DateHelper.IsSameDay(dateRange.startDate, dateRange.endDate) ?
        DateHelper.IsBetween(x.startTime, dateRange.startDate, dateRange.endDate)
        : DateHelper.IsSameDay(x.startTime, dateRange.startDate)))
  );
}

export function examsByDateSelector(store: Store<any>): Observable<{ [key: string]: Exam[] }> {
  return userExamsSelector(store).pipe(
    map(x =>
      x.reduce((acc, y) => {
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
