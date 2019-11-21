import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { CurrentUser } from 'src/app/shared/models';
import { userSelector } from 'src/app/shared/selectors';

@Component({
  selector: 'rvu-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent extends SmartComponent implements OnInit {
  @Control(CurrentUser) form: FormGroup;
  _user: CurrentUser = new CurrentUser();
  user$: Observable<CurrentUser>;

  constructor(public store: Store<any>) {
    super(store);
    this.user$ = userSelector(store);
  }

  set user(value: CurrentUser) {
    console.dir(value);
    this._user = value;
    this.setValue(value);
  }

  get user(): CurrentUser {
    return this._user;
  }

  ngOnInit() {
    console.dir(this.form.controls);
    this.sync(['user']);
  }
}
