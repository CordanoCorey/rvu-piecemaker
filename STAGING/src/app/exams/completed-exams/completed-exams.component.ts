import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent, compareDates, build, ConfirmDeleteComponent, HttpActions, compareStrings, roundToDecimalPlace } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Exam } from '../exams.model';
import { completedExamsSelector, ExamActions } from '../exams.reducer';
import { ExamTypeRow } from '../../exam-types/exam-types.model';
import { ExamFormComponent } from '../../exam/exam-form/exam-form.component';

@Component({
  selector: 'rvu-completed-exams',
  templateUrl: './completed-exams.component.html',
  styleUrls: ['./completed-exams.component.scss']
})
export class CompletedExamsComponent extends SmartComponent implements OnInit {
  @Input() groupByExamType = false;
  completedExams: Exam[] = [];
  completedExams$: Observable<Exam[]>;
  deleting: Exam;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.completedExams$ = completedExamsSelector(store);
  }

  get data(): Exam[] | ExamTypeRow[] {
    return this.groupByExamType
      ? this.completedExams
          .reduce((acc, x) => {
            const existing = build(ExamTypeRow, acc.find(y => y.examTypeId === x.examTypeId));
            const row = build(ExamTypeRow, existing, {
              examTypeId: x.examTypeId,
              name: x.name,
              cptCode: x.cptCode,
              modalityName: x.modalityName,
              rvuEach: x.rvuTotal,
              count: existing.count + 1
            });
            return [...acc.filter(y => y.examTypeId !== x.examTypeId), row];
          }, [])
          .sort((a, b) => compareStrings(a.name, b.name))
      : this.completedExams.sort((a, b) => compareDates(a.createdDate, b.createdDate));
  }

  get displayedColumns(): string[] {
    return this.groupByExamType ? ['name', 'cptCode', 'modalityName', 'rvuEach', 'count', 'rvuTotal'] : ['actions', 'name', 'createdDate', 'notes', 'rvuTotal'];
  }

  get gridTitle(): string {
    return this.groupByExamType ? 'Exam Types' : 'Exams';
  }

  get totalRVUs(): number {
    return roundToDecimalPlace(this.completedExams.reduce((acc, x) => acc + x.rvuTotal, 0), 2);
  }

  ngOnInit() {
    this.sync(['completedExams']);
  }

  closeDialog(e: any) {
    if (this.deleting && e) {
      this.deleteExam(this.deleting);
      this.deleting = null;
    }
    super.closeDialog(e);
  }

  onDeleteExam(e: Exam) {
    this.deleting = e;
    this.openDialog(ConfirmDeleteComponent);
  }

  deleteExam(e: Exam) {
    this.dispatch(HttpActions.delete(`exams/${e.id}`, e.id, ExamActions.DELETE));
  }

  editExam(data: Exam) {
    this.openDialog(ExamFormComponent, { data });
  }
}
