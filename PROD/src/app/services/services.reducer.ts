import { Action, routeParamIdSelector, compareStrings } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Services, Service } from './services.model';

export class ServicesActions {
  static GET = '[Services] GET';
}

export class ServiceActions {
  static PUT = '[Services] PUT';
  static PUT_ERROR = '[Services] PUT ERROR';
}

export function servicesReducer(state: Services = new Services(), action: Action): Services {
  switch (action.type) {
    case ServicesActions.GET:
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
