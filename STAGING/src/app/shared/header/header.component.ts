import { Component, OnInit, Input } from '@angular/core';
import { SmartComponent, HttpActions, SidenavActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { CurrentUserActions } from '../../shared/actions';
import { userIdSelector, userNameSelector } from '../../shared/selectors';

@Component({
  selector: 'rvu-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent extends SmartComponent implements OnInit {
  @Input() isMobile = false;
  userId$: Observable<number>;
  userName$: Observable<string>;
  _userId = 0;

  constructor(public store: Store<any>) {
    super(store);

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
    this.sync(['userId']);
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

  toggleSidenav() {
    this.store.dispatch(SidenavActions.toggle());
  }
}
