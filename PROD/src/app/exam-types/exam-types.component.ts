import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, HttpActions, inArray, build, routeParamIdSelector, MessageSubscription, compareStrings } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject, combineLatest } from 'rxjs';

import { ExamType } from './exam-types.model';
import { examTypesSelector, ExamTypesActions } from './exam-types.reducer';
import { ExamTypeFormComponent } from './exam-type-form/exam-type-form.component';
import { ExamFormComponent } from '../exam/exam-form/exam-form.component';
import { Exam } from '../exams/exams.model';
import { ExamsActions } from '../exams/exams.reducer';
import { Shift } from '../shifts/shifts.model';
import { ExamGroup } from '../shared/models';
import { shiftSelector } from '../shifts/shifts.reducer';
import { examGroupsSelector, activeDateSelector, userIdSelector } from '../shared/selectors';
import { ExamGroupsActions } from '../shared/actions';

@Component({
  selector: 'rvu-exam-types',
  templateUrl: './exam-types.component.html',
  styleUrls: ['./exam-types.component.scss']
})
export class ExamTypesComponent extends SmartComponent implements OnInit {
  date: Date = new Date();
  date$: Observable<Date>;
  examTypeId = 0;
  examTypes$: Observable<ExamType[]>;
  filteredExamTypes$: Observable<ExamType[]>;
  groupId = 0;
  groupId$: Observable<number>;
  groupIdSubject = new BehaviorSubject<number>(0);
  messages = [
    build(MessageSubscription, {
      action: ExamsActions.POST,
      channel: 'TOASTS',
      mapper: e => `Exam saved successfully!`
    }),
    build(MessageSubscription, {
      action: ExamsActions.POST_ERROR,
      channel: 'ERRORS',
      mapper: e => `Failed to save exam.`
    })
  ];
  searchTermSubject = new BehaviorSubject<string>('');
  serviceId = 0;
  serviceId$: Observable<number>;
  shift: Shift = new Shift();
  shift$: Observable<Shift>;
  shiftId = 0;
  shiftId$: Observable<number>;
  showErrorMessage = false;
  examGroups$: Observable<ExamGroup[]>;
  _examTypes: ExamType[] = [];
  userId = 0;
  userId$: Observable<number>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.userId$ = userIdSelector(store);
    this.date$ = activeDateSelector(store);
    this.examTypes$ = examTypesSelector(store);
    this.groupId$ = this.groupIdSubject.asObservable();
    this.serviceId$ = routeParamIdSelector(store, 'serviceId');
    this.shift$ = shiftSelector(store);
    this.shiftId$ = routeParamIdSelector(store, 'shiftId');
    this.examGroups$ = examGroupsSelector(store);
    this.filteredExamTypes$ = combineLatest(this.examTypes$, this.groupId$, this.searchTermSubject.asObservable(), (examTypes, groupId, searchTerm) => {
      return examTypes
        .filter(x => (groupId === 0 || inArray(x.examGroupIds, groupId)) && (!searchTerm || x.name.toLowerCase().includes(searchTerm.toLowerCase())))
        .sort((a, b) => compareStrings(a.name, b.name));
    });
  }

  set examTypes(value: ExamType[]) {
    this._examTypes = value;
  }

  get examTypes(): ExamType[] {
    return this._examTypes;
  }

  get groupName(): string {
    return build(ExamType, this.examTypes.find(x => x.id === this.groupId)).name || 'ALL';
  }

  ngOnInit() {
    this.sync(['date', 'groupId', 'serviceId', 'shift', 'shiftId', 'userId']);
    this.onInit();
    this.getExamTypes();
    this.getExamGroups();
  }

  onAddExam(e, type: ExamType) {
    e.stopPropagation();
    if (!this.serviceId) {
      this.showErrorMessage = true;
      setTimeout(() => {
        this.showErrorMessage = false;
      }, 5000);
    } else {
      this.addExam(
        build(Exam, {
          examTypeId: type.id,
          serviceId: this.serviceId,
          shiftId: this.shiftId || null,
          shift: build(Shift, this.shift, {
            id: 0,
            shiftTypeId: 1
          }),
          startTime: this.date,
          endTime: null,
          userId: this.userId
        })
      );
    }
  }

  addExam(exam: Exam) {
    this.dispatch(HttpActions.post(`exams`, exam, ExamsActions.POST, ExamsActions.POST_ERROR));
  }

  changeGroupId(e: number) {
    this.groupIdSubject.next(e);
  }

  changeSearchTerm(e: string) {
    this.searchTermSubject.next(e);
  }

  closeDialog(e: any) {}

  changeService(e: number) {}

  editExamType(data: ExamType) {
    this.examTypeId = data.id;
    this.openDialog(ExamTypeFormComponent, {
      data
    });
  }

  getExamGroups() {
    this.dispatch(HttpActions.get(`examgroups`, ExamGroupsActions.GET));
  }

  getExamTypes() {
    this.dispatch(HttpActions.get(`examtypes`, ExamTypesActions.GET));
  }

  openExamDialog() {
    this.openDialog(ExamFormComponent);
  }

  openExamTypeDialog() {
    this.openDialog(ExamTypeFormComponent);
  }
}
