import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import {
  SmartComponent,
  Control,
  LookupValue,
  build,
  HttpActions,
  windowHeightSelector,
  windowWidthSelector,
  NewUser
} from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';

import { CurrentUserActions } from '../shared/actions';
import { authenticatedSelector } from '../shared/selectors';

@Component({
  selector: 'rvu-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent extends SmartComponent implements OnInit {
  @Control(NewUser) form: FormGroup;
  authenticated = false;
  authenticated$: Observable<boolean>;
  header$: Observable<string>;
  roles$: Observable<LookupValue[]>;
  windowHeight$: Observable<number>;
  windowWidth$: Observable<number>;

  constructor(public store: Store<any>) {
    super(store);
    this.authenticated$ = authenticatedSelector(store);
    this.windowHeight$ = windowHeightSelector(store);
    this.windowWidth$ = windowWidthSelector(store);
  }

  get authenticatedChanges(): Subscription {
    return this.authenticated$.subscribe(x => {
      this.authenticated = x;
    });
  }

  get message(): string {
    return this.inErrorState ? `An error has occurred in the API.` : '';
  }

  get newUser(): NewUser {
    return build(NewUser, this.form.value);
  }

  ngOnInit() {
    this.subscribe([this.authenticatedChanges]);
  }

  submit() {
    this.dispatch(
      HttpActions.post(
        'users',
        this.newUser,
        CurrentUserActions.SIGNUP
      )
    );
  }
}
