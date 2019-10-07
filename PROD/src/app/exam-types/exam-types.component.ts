import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, HttpActions, inArray, build, routeParamIdSelector, MessageSubscription } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject, combineLatest } from 'rxjs';

import { ExamType } from './exam-types.model';
import { examTypesSelector, ExamTypesActions } from './exam-types.reducer';
import { ExamTypeFormComponent } from './exam-type-form/exam-type-form.component';
import { ExamFormComponent } from '../exam/exam-form/exam-form.component';
import { Exam } from '../exams/exams.model';
import { ExamsActions } from '../exams/exams.reducer';
import { Shift } from '../shifts/shifts.model';
import { Tag } from '../shared/models';
import { shiftSelector } from '../shifts/shifts.reducer';
import { tagsSelector } from '../shared/selectors';
import { TagsActions } from '../shared/actions';

@Component({
  selector: 'rvu-exam-types',
  templateUrl: './exam-types.component.html',
  styleUrls: ['./exam-types.component.scss']
})
export class ExamTypesComponent extends SmartComponent implements OnInit {
  examTypeId = 0;
  examTypes$: Observable<ExamType[]>;
  filteredExamTypes$: Observable<ExamType[]>;
  groupId = 0;
  groupId$: Observable<number>;
  groupIdSubject = new BehaviorSubject<number>(0);
  messages = [
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
  tags$: Observable<Tag[]>;
  _examTypes: ExamType[] = [];

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.examTypes$ = examTypesSelector(store);
    this.groupId$ = this.groupIdSubject.asObservable();
    this.serviceId$ = routeParamIdSelector(store, 'serviceId');
    this.shift$ = shiftSelector(store);
    this.shiftId$ = routeParamIdSelector(store, 'shiftId');
    this.tags$ = tagsSelector(store);
    this.filteredExamTypes$ = combineLatest(this.examTypes$, this.groupId$, this.searchTermSubject.asObservable(), (examTypes, groupId, searchTerm) => {
      return examTypes.filter(x => (groupId === 0 || inArray(x.tagIds, groupId)) && (!searchTerm || x.name.toLowerCase().includes(searchTerm.toLowerCase())));
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
    this.sync(['groupId', 'serviceId', 'shift', 'shiftId']);
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
          shiftId: this.shiftId,
          shift: build(Shift, this.shift, {
            id: 0,
            shiftTypeId: 1
          })
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
    this.dispatch(HttpActions.get(`tags`, TagsActions.GET));
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
