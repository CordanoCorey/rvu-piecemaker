import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { SmartComponent, Control, build, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { ExamGroup } from '../exam-groups.model';
import { examGroupSelector, ExamGroupsActions, ExamGroupActions } from '../exam-groups.reducer';

@Component({
  selector: 'rvu-exam-group-form',
  templateUrl: './exam-group-form.component.html',
  styleUrls: ['./exam-group-form.component.scss']
})
export class ExamGroupFormComponent extends SmartComponent implements OnInit {
  @Control(ExamGroup) form: FormGroup;
  _examGroup: ExamGroup = new ExamGroup();
  examGroup$: Observable<ExamGroup>;

  constructor(public store: Store<any>) {
    super(store);
    this.examGroup$ = examGroupSelector(store);
  }

  set examGroup(value: ExamGroup) {
    this.setValue(value);
    this._examGroup = value;
  }

  get examGroup(): ExamGroup {
    return this._examGroup;
  }

  get valueOut(): ExamGroup {
    return build(ExamGroup, this.examGroup, this.form.value);
  }

  ngOnInit() {
    this.sync(['examGroup']);
  }

  onSave() {
    if (!this.examGroup.id) {
      this.add(this.valueOut);
    } else {
      this.update(this.valueOut);
    }
  }

  add(e: ExamGroup) {
    this.dispatch(HttpActions.post(`examgroups`, e, ExamGroupsActions.POST, ExamGroupsActions.POST_ERROR));
  }

  update(e: ExamGroup) {
    this.dispatch(HttpActions.put(`examgroups/${e.id}`, e, ExamGroupActions.PUT, ExamGroupActions.PUT_ERROR));
  }
}
