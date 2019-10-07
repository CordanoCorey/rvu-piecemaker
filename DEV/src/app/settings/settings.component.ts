import { Component, OnInit } from '@angular/core';
import { SmartComponent, build } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { TabsActions } from '../shared/actions';
import { Tab } from '../shared/models';

@Component({
  selector: 'rvu-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent extends SmartComponent implements OnInit {
  routeName$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
  }

  get tabs(): Tab[] {
    return [
      build(Tab, { label: 'User Settings', routerLink: '/settings' }),
      build(Tab, { label: 'Goals', routerLink: '/settings/goals' }),
      build(Tab, { label: 'Services', routerLink: '/settings' }),
      build(Tab, { label: 'Users', routerLink: '/settings' })
    ];
  }

  ngOnInit() {
    this.dispatch(TabsActions.activate(this.tabs));
  }
}
