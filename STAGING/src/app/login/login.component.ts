import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, HttpActions, SmartComponent, MessagesActions, MessageSubscription, build } from '@caiu/library';
import { Store } from '@ngrx/store';

import { CurrentUserActions } from '../shared/actions';
import { Login } from '../shared/models';

@Component({
  selector: 'rvu-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends SmartComponent implements OnInit {
  @Control(Login) form: FormGroup;
  messages = [
    build(MessageSubscription, {
      action: CurrentUserActions.LOGIN_ERROR,
      channel: 'ERRORS',
      mapper: e => e.message || `Login Failed.`
    })
  ];

  constructor(public store: Store<any>) {
    super(store);
  }

  get credentials(): string {
    return `grant_type=password&email=${this.form.value.email}&password=${this.form.value.password}`;
  }

  get emailAddress(): string {
    return this.form.controls.email.value;
  }

  ngOnInit() {
    this.onInit();
  }

  login() {
    if (this.form.valid) {
      this.dispatch(HttpActions.postFormUrlEncoded('token', this.credentials, CurrentUserActions.LOGIN, CurrentUserActions.LOGIN_ERROR));
    }
  }

  resetPassword() {
    this.dispatch(HttpActions.post(`resetpassword/${this.emailAddress}`, {}, CurrentUserActions.GENERATE_PASSWORD_RESET_CODE));
  }
}
