import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions, build, MessageSubscription } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Exam } from './exams.model';
import { ExamGroup } from './exam-groups.model';
import { ExamGroupsActions, ExamGroupActions } from './exam-groups.reducer';
import { examGroupsSelector } from '../shared/selectors';

@Component({
  selector: 'rvu-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.scss']
})
export class ExamsComponent extends SmartComponent implements OnInit {
  exams$: Observable<Exam[]>;
  examGroups$: Observable<ExamGroup[]>;
  messages = [
    build(MessageSubscription, {
      action: ExamGroupsActions.POST,
      channel: 'TOASTS',
      mapper: e => `Exam Group saved successfully!`
    }),
    build(MessageSubscription, {
      action: ExamGroupsActions.POST_ERROR,
      channel: 'ERRORS',
      mapper: e => `Failed to save exam group.`
    }),
    build(MessageSubscription, {
      action: ExamGroupActions.PUT,
      channel: 'TOASTS',
      mapper: e => `Exam Group saved successfully!`
    }),
    build(MessageSubscription, {
      action: ExamGroupActions.PUT_ERROR,
      channel: 'ERRORS',
      mapper: e => `Failed to save exam group.`
    })
  ];

  constructor(public store: Store<any>) {
    super(store);
    this.examGroups$ = examGroupsSelector(store);
  }

  ngOnInit() {
    this.getExamGroups();
    this.onInit();
  }

  getExamGroups() {
    this.dispatch(HttpActions.get(`examgroups`, ExamGroupsActions.GET));
  }
}
