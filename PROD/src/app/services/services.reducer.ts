import { Action, routeParamIdSelector } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { Services, Service } from './services.model';

export class ServicesActions {
  static GET = '[Services] GET';
}

export class ServiceActions {
  static PUT = '[Services] PUT';
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
  return store.select('services').pipe(map(x => x.asArray));
}

export function serviceSelector(store: Store<any>): Observable<Service> {
  return combineLatest(store.select('services'), routeParamIdSelector(store, 'serviceId'), (services, id) => services.get(id));
}
