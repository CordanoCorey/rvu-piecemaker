import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Goal } from './goals.model';
import { goalSelector } from './goals.reducer';

@Component({
  selector: 'rvu-goals',
  templateUrl: './goals.component.html',
  styleUrls: ['./goals.component.scss']
})
export class GoalsComponent extends SmartComponent implements OnInit {
  goal: Goal = new Goal();
  goal$: Observable<Goal>;

  constructor(public store: Store<any>, public dialog: MatDialog) {
    super(store);
    this.goal$ = goalSelector(store);
  }

  ngOnInit() {
    this.sync(['goal']);
  }
}
