import { Injectable } from '@angular/core';
import {
  configReducer,
  errorsReducer,
  eventsReducer,
  formReducer,
  lookupReducer,
  messagesReducer,
  redirectsReducer,
  routerReducer,
  sidenavReducer,
  viewSettingsReducer,
  windowReducer
} from '@caiu/library';
import { ActionReducerMap } from '@ngrx/store';

import { examsReducer } from './exams/exams.reducer';
import { examTypesReducer } from './exam-types/exam-types.reducer';
import { goalsReducer } from './goals/goals.reducer';
import { shiftsReducer } from './shifts/shifts.reducer';
import { currentUserReducer, tabsReducer, tagsReducer, servicesReducer } from './shared/reducers';

@Injectable({
  providedIn: 'root'
})
export class ReducersService {
  constructor() {}

  getReducers(): ActionReducerMap<any> {
    return {
      currentUser: currentUserReducer,
      config: configReducer,
      errors: errorsReducer,
      events: eventsReducer,
      form: formReducer,
      lookup: lookupReducer,
      messages: messagesReducer,
      redirects: redirectsReducer,
      route: routerReducer,
      sidenav: sidenavReducer,
      viewSettings: viewSettingsReducer,
      window: windowReducer,
      exams: examsReducer,
      examTypes: examTypesReducer,
      goals: goalsReducer,
      services: servicesReducer,
      shifts: shiftsReducer,
      tabs: tabsReducer,
      tags: tagsReducer
    };
  }
}
