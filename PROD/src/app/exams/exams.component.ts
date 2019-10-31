import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Exam } from './exams.model';
import { ExamGroup } from './exam-groups.model';
import { examGroupsSelector } from '../shared/selectors';

@Component({
  selector: 'rvu-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.scss']
})
export class ExamsComponent extends SmartComponent implements OnInit {
  exams$: Observable<Exam[]>;
  examGroups$: Observable<ExamGroup[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.examGroups$ = examGroupsSelector(store);
  }

  ngOnInit() {
    this.getExamGroups();
  }

  getExamGroups() {
    this.dispatch(HttpActions.get(`examgroups`));
  }
}
