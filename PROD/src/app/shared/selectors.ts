import { build, Token, routeParamSelector, lookupValuesSelector, LookupValue, routeParamIdSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, interval, combineLatest } from 'rxjs';
import { map, distinctUntilChanged, take } from 'rxjs/operators';

import { CurrentUser, ExamGroup, Tab } from './models';

export function isAdminUserSelector(store: Store<any>): Observable<boolean> {
  return userSelector(store).pipe(
    map(x => x.isAdmin),
    distinctUntilChanged()
  );
}

export function authenticatedSelector(store: Store<any>): Observable<boolean> {
  return userSelector(store).pipe(
    map(user => user.authenticated),
    take(1)
  );
}

export function authTokenSelector(store: Store<any>): Observable<string> {
  return userSelector(store).pipe(
    map(user => {
      const token: Token = user && user.token ? build(Token, user.token) : new Token();
      return token.toString();
    })
  );
}

export function currentTimeSelector(store: Store<any>): Observable<Date> {
  return interval(60000).pipe(
    map(x => {
      const d = new Date();
      d.setTime(d.getTime() + 60 * 1000);
      return d;
    })
  );
}

export function doctorTypesSelector(store: Store<any>): Observable<LookupValue[]> {
  return lookupValuesSelector(store, 'DoctorType');
}

export function lookupModalities(store: Store<any>): Observable<LookupValue[]> {
  return lookupValuesSelector(store, 'Modality');
}

export function redirectToSelector(store: Store<any>): Observable<string> {
  return routeParamSelector(store, 'redirectTo', 'dashboard').pipe(distinctUntilChanged());
}

export function tabsSelector(store: Store<any>): Observable<Tab[]> {
  return store.select('tabs').pipe(map(x => x.asArray));
}

export function examGroupsSelector(store: Store<any>): Observable<ExamGroup[]> {
  return store.select('examGroups').pipe(map(x => x.asArray));
}

export function userSelector(store: Store<any>): Observable<CurrentUser> {
  return store.select('currentUser').pipe(map(user => build(CurrentUser, user)));
}

export function userIdSelector(store: Store<any>): Observable<number> {
  return userSelector(store).pipe(
    map(x => x.id),
    distinctUntilChanged()
  );
}

export function userNameSelector(store: Store<any>): Observable<string> {
  return userSelector(store).pipe(
    map(x => x.fullName),
    distinctUntilChanged()
  );
}

export function rvuRateSelector(store: Store<any>): Observable<number> {
  return userSelector(store).pipe(
    map(x => x.rvuRate),
    distinctUntilChanged()
  );
}

export function activeDateSelector(store: Store<any>): Observable<Date> {
  return routeParamSelector(store, 'date').pipe(map(x => (x ? new Date(x) : new Date())));
}
