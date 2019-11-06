import { Component, OnInit } from '@angular/core';
import { SmartComponent, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { userIdSelector, userNameSelector } from '../shared/selectors';

@Component({
  selector: 'rvu-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends SmartComponent implements OnInit {
  userId$: Observable<number>;
  userName$: Observable<string>;
  _userId = 0;

  constructor(public store: Store<any>) {
    super(store);
    // assign the results of selectors to local observables in the constructor
    this.userId$ = userIdSelector(store);
    this.userName$ = userNameSelector(store);
  }

  set userId(value: number) {
    this._userId = value;
  }

  get userId(): number {
    return this._userId;
  }

  ngOnInit() {
    // sync keeps values emitted by the observable in sync with the local synchronous property
    this.sync(['userId']);
  }
}
