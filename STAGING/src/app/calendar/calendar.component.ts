import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { build, CalendarEvent, CalendarTime, Calendar, CalendarDay, CalendarEventType } from '@caiu/library';

@Component({
  selector: 'rvu-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CalendarComponent implements OnInit {
  calendarDayTypes: CalendarEventType[] = [
    build(CalendarEventType, { id: 1, name: 'Inactive', allDay: true, color: 'silver' }),
    build(CalendarEventType, { id: 2, name: 'Off', allDay: true, color: '#e57373' }),
    build(CalendarEventType, { id: 3, name: 'Shift', allDay: true, color: '#00568c' })
  ];

  today = new Date();

  constructor() {}

  get endDate(): Date {
    return new Date(this.today.getFullYear() + 1, 12, 31);
  }

  ngOnInit() {}
}
