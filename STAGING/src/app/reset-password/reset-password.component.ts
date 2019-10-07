import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ResetPassword, Control, SmartComponent, routeParamSelector, HttpActions } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'rvu-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent extends SmartComponent implements OnInit {
  @Control(ResetPassword) form: FormGroup;
  passwordResetCode$: Observable<string>;
  showLoginLink = false;
  _passwordResetCode = '';

  constructor(public store: Store<any>) {
    super(store);
    this.passwordResetCode$ = routeParamSelector(store, 'code');
  }

  set passwordResetCode(value: string) {
    this._passwordResetCode = value;
    this.form.setValue({
      passwordResetCode: value,
      password: '',
      confirmPassword: ''
    });
  }

  get passwordResetCode(): string {
    return this._passwordResetCode;
  }

  get valueOut(): any {
    return Object.assign({}, this.form.value, {
      passwordResetCode: this.passwordResetCode
    });
  }

  ngOnInit() {
    this.sync(['passwordResetCode']);
  }

  submit() {
    this.dispatch(HttpActions.post(`resetpassword`, this.valueOut));
  }
}
