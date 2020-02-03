import { Component, OnInit } from '@angular/core';
import { Control, DateRange, SmartComponent, RouterActions, DateHelper } from '@caiu/library';
import { FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { combineLatest, Observable } from 'rxjs';
import { startWith } from 'rxjs/operators';

import { activeDateRangeSelector } from '../shared/selectors';

@Component({
  selector: 'rvu-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent extends SmartComponent implements OnInit {

  @Control(DateRange) form: FormGroup;
  _dateRange: DateRange = new DateRange();
  dateRange$: Observable<DateRange>;

  constructor(public store: Store<any>) {
    super(store);
    this.dateRange$ = activeDateRangeSelector(store);
  }

  set dateRange(value: DateRange) {
    this._dateRange = value;
    this.form.setValue(value);
  }

  get dateRange(): DateRange {
    return this._dateRange;
  }

  ngOnInit() {
    this.sync(['dateRange']);
    this.addSubscription(
      combineLatest(this.form.get('startDate').valueChanges.pipe(startWith(this.form.value.startDate)),
        this.form.get('endDate').valueChanges.pipe(startWith(this.form.value.endDate)), (startDate, endDate) => ({ startDate, endDate })).subscribe(x => {
          if (x.startDate) {
            this.redirect(x.startDate, x.endDate);
          }
        })
    );
  }

  redirect(startDate: Date, endDate?: Date) {
    const url = endDate ?
      `reports?date=${DateHelper.FormatDateSlashes(startDate)}&endDate=${DateHelper.FormatDateSlashes(endDate)}`
      : `reports?date=${DateHelper.FormatDateSlashes(startDate)}`;
    this.dispatch(RouterActions.navigate(url));
  }

}
