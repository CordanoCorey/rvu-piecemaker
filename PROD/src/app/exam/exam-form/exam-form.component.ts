import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Control, SmartComponent, HttpActions, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Exam } from '../../exams/exams.model';
import { ExamType } from '../../exam-types/exam-types.model';
import { examTypesSelector } from '../../exam-types/exam-types.reducer';
import { ExamActions, ExamsActions } from '../../exams/exams.reducer';
import { Service } from 'src/app/services/services.model';
import { servicesSelector } from 'src/app/services/services.reducer';

@Component({
  selector: 'rvu-exam-form',
  templateUrl: './exam-form.component.html',
  styleUrls: ['./exam-form.component.scss']
})
export class ExamFormComponent extends SmartComponent implements OnInit {
  @Control(Exam) form: FormGroup;
  examTypes$: Observable<ExamType[]>;
  services$: Observable<Service[]>;
  _exam: Exam = new Exam();

  constructor(public store: Store<any>, public dialogRef?: MatDialogRef<ExamFormComponent>, @Inject(MAT_DIALOG_DATA) public data?: Exam) {
    super(store);
    this.examTypes$ = examTypesSelector(store);
    this.services$ = servicesSelector(store);
    this.exam = data;
  }

  set exam(value: Exam) {
    this._exam = value;
    this.setValue(value);
  }

  get exam(): Exam {
    return this._exam;
  }

  get valueOut(): Exam {
    return build(Exam, this.data, this.form.value);
  }

  ngOnInit() {}

  onDelete() {
    this.deleteExam(this.valueOut);
    this.dialogRef.close();
  }

  onSave() {
    this.updateExam(this.valueOut);
    this.dialogRef.close();
  }

  addExam(e: Exam) {
    this.dispatch(HttpActions.post(`exams`, e, ExamsActions.POST));
  }

  deleteExam(e: Exam) {
    this.dispatch(HttpActions.delete(`exams/${e.id}`, e.id, ExamActions.DELETE));
  }

  updateExam(e: Exam) {
    this.dispatch(HttpActions.put(`exams/${e.id}`, e, ExamActions.PUT));
  }
}
