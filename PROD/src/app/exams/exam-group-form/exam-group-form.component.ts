import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { SmartComponent, Control, build, HttpActions, ConfirmDeleteComponent } from '@caiu/library';
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
  constructor(public store: Store<any>, public dialog: MatDialog) {
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
  @Control(ExamGroup) form: FormGroup;
  _examGroup: ExamGroup = new ExamGroup();
  examGroup$: Observable<ExamGroup>;

  ngOnInit() {
    this.sync(['examGroup']);
  }

  closeDialog(e: boolean) {
    if (e) {
      this.delete(this.examGroup.id);
    }
  }

  delete(id: number) {
    this.dispatch(HttpActions.delete(`examgroups/${id}`, id, ExamGroupActions.DELETE, ExamGroupActions.DELETE_ERROR));
  }

  onDelete() {
    this.openDialog(ConfirmDeleteComponent, { width: '600px' });
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
