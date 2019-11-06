import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Goal } from './goals.model';
import { goalSelector, nonzeroRvuTotalsSelector } from './goals.reducer';
import { rvuTotalByDateSelector } from '../exams/exams.reducer';

@Component({
  selector: 'rvu-goals',
  templateUrl: './goals.component.html',
  styleUrls: ['./goals.component.scss']
})
export class GoalsComponent extends SmartComponent implements OnInit {
  goal: Goal = new Goal();
  goal$: Observable<Goal>;
  rvuTotals: number[] = [];
  rvuTotals$: Observable<number[]>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.goal$ = goalSelector(store);
    this.rvuTotals$ = nonzeroRvuTotalsSelector(store);
    // this.goal$.subscribe(x => {
    //   console.dir(x);
    // });
  }

  get rvusPerDay(): number {
    return this.totalRvus / this.rvuTotals.length;
  }

  get totalRvus(): number {
    return this.rvuTotals.reduce((acc, x) => acc + x, 0);
  }

  ngOnInit() {
    this.sync(['goal', 'rvuTotals']);
  }
}
