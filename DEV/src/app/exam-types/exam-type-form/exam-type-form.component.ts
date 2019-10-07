import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, SmartComponent, LookupValue, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { ExamType } from '../exam-types.model';
import { ExamTypesActions, ExamTypeActions } from '../exam-types.reducer';
import { lookupModalities, isAdminUserSelector, doctorTypesSelector } from '../../shared/selectors';

@Component({
  selector: 'rvu-exam-type-form',
  templateUrl: './exam-type-form.component.html',
  styleUrls: ['./exam-type-form.component.scss']
})
export class ExamTypeFormComponent extends SmartComponent implements OnInit {
  @Control(ExamType) form: FormGroup;
  doctorTypes$: Observable<LookupValue[]>;
  isAdminUser$: Observable<boolean>;
  modalities$: Observable<LookupValue[]>;
  _examType: ExamType = new ExamType();

  constructor(public store: Store<any>) {
    super(store);
    this.isAdminUser$ = isAdminUserSelector(store);
    this.doctorTypes$ = doctorTypesSelector(store);
    this.modalities$ = lookupModalities(store);
  }

  @Input()
  set examType(value: ExamType) {
    this.setValue(value);
  }

  get examType(): ExamType {
    return this._examType;
  }

  ngOnInit() {}

  addExamType(e: ExamType) {
    this.dispatch(HttpActions.post(`examtypes`, e, ExamTypesActions.POST));
  }

  deleteExamType(e: ExamType) {
    this.dispatch(HttpActions.delete(`examtypes/${e.id}`, e.id, ExamTypeActions.DELETE));
  }

  updateExamType(e: ExamType) {
    this.dispatch(HttpActions.put(`examtypes/${e.id}`, e, ExamTypeActions.PUT));
  }
}
