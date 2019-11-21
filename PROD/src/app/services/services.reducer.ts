import { Action, routeParamIdSelector, compareStrings, inArray } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Services, Service } from './services.model';
import { completedExamsSelector } from '../exams/exams.reducer';

export class ServicesActions {
  static GET = '[Services] GET';
  static POST = '[Services] POST';
  static POST_ERROR = '[Services] POST ERROR';
}

export class ServiceActions {
  static PUT = '[Service] PUT';
  static PUT_ERROR = '[Service] PUT ERROR';
}

export function servicesReducer(state: Services = new Services(), action: Action): Services {
  switch (action.type) {
    case ServicesActions.GET:
    case ServicesActions.POST:
    case ServiceActions.PUT:
      return state.update(action.payload);
    default:
      return state;
  }
}

export function servicesSelector(store: Store<any>): Observable<Service[]> {
  return store.select('services').pipe(
    map(x => {
      const services = x.asArray;
      const am = services.filter(y => y.name.includes('(AM)')).sort((a, b) => compareStrings(a.name, b.name));
      const pm = services.filter(y => y.name.includes('(PM)')).sort((a, b) => compareStrings(a.name, b.name));
      const other = services.filter(y => !(y.name.includes('(AM)') || y.name.includes('(PM)'))).sort((a, b) => compareStrings(a.name, b.name));
      return [...am, ...pm, ...other];
    })
  );
}

export function serviceSelector(store: Store<any>): Observable<Service> {
  return combineLatest(store.select('services'), routeParamIdSelector(store, 'serviceId'), (services, id) => services.get(id));
}

export function shiftServicesSelector(store: Store<any>): Observable<Service[]> {
  return combineLatest(store.select('services'), completedExamsSelector(store), (services, exams) => {
    const ids = exams.map(x => x.serviceId);
    return services.asArray.filter(x => inArray(ids, x.id));
  })
}
