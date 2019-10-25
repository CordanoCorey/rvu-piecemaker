import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { build, SmartComponent, RouterActions, DateHelper, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Exam } from '../exams/exams.model';
import { ExamsActions, examsByDateSelector, rvuTotalByDateSelector } from '../exams/exams.reducer';
import { CalendarEventType, CalendarDay } from '../shared/calendar/calendar.model';

@Component({
  selector: 'rvu-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ScheduleComponent extends SmartComponent implements OnInit {
  calendarDayTypes: CalendarEventType[] = [
    build(CalendarEventType, { id: 1, name: 'Inactive', allDay: true, color: 'silver' }),
    build(CalendarEventType, { id: 2, name: 'Off', allDay: true, color: '#e57373' }),
    build(CalendarEventType, { id: 3, name: 'Shift', allDay: true, color: '#00568c' })
  ];
  rvuTotals: { [key: string]: number } = {};
  rvuTotals$: Observable<{ [key: string]: number }>;
  today = new Date();

  constructor(public store: Store<any>) {
    super(store);
    this.rvuTotals$ = rvuTotalByDateSelector(store);
  }

  get endDate(): Date {
    return new Date(this.today.getFullYear() + 1, 12, 31);
  }

  ngOnInit() {
    this.sync(['rvuTotals']);
    this.getExams();
  }

  getExams() {
    this.dispatch(HttpActions.get(`exams/user`, ExamsActions.GET));
  }

  getRvuTotal(e: CalendarDay): number {
    return this.rvuTotals[DateHelper.FormatDateSlashes(e.date)] || 0;
  }

  onGoToDay(e: CalendarDay) {
    this.dispatch(RouterActions.navigate(`/shifts/0?date=${DateHelper.FormatDateSlashes(e.date)}`));
  }
}
