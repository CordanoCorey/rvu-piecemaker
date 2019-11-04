import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { RouterActions, Action } from '@caiu/library';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ExamGroupsActions } from './exam-groups.reducer';

@Injectable()
export class ExamsEffects {
  /**
   * Redirect to exam group form after adding exam group.
   */
  @Effect() onAddExamGroup: Observable<Action> = this.actions$.pipe(
    ofType(ExamGroupsActions.POST),
    map((action: Action) => RouterActions.navigate(`/exams/${action.payload.id}`))
  );

  constructor(private actions$: Actions, public store: Store<any>) {}
}
