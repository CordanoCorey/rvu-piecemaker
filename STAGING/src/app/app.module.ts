import { BrowserModule } from '@angular/platform-browser';
import { NgModule, InjectionToken } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import {
  ErrorsModule,
  EventEffects,
  HttpModule,
  HttpEffects,
  LookupModule,
  RouterModule,
  RouterEffects,
  StorageModule,
  StorageEffects,
  StoreModule,
  apiBaseUrlSelector,
  MessagesEffects
} from '@caiu/library';
import { EffectsModule } from '@ngrx/effects';
import { ActionReducerMap } from '@ngrx/store';
import 'hammerjs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReducersService } from './reducers.service';
import { UserEffects } from './shared/effects';
import { authTokenSelector } from './shared/selectors';
import { SharedModule } from './shared/shared.module';
import { GoalsEffects } from './goals/goals.effects';
import { ShiftsEffects } from './shifts/shifts.effects';

export const REDUCER_TOKEN = new InjectionToken<ActionReducerMap<any>>('Registered Reducers');

export function getReducers(reducersService: ReducersService) {
  return reducersService.getReducers();
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    EffectsModule.forRoot([EventEffects, HttpEffects, MessagesEffects, RouterEffects, UserEffects, StorageEffects, ShiftsEffects]),
    ErrorsModule.forRoot(),
    FlexLayoutModule,
    FormsModule,
    HttpClientModule,
    HttpModule.forRoot(apiBaseUrlSelector, authTokenSelector),
    LookupModule.forRootWithPath('Lookup'),
    RouterModule.forRoot(),
    SharedModule.forRoot(),
    StorageModule.forRoot('RVU_STORE'),
    StoreModule.forRoot(REDUCER_TOKEN, {
      initialState: {}
    })
  ],
  providers: [
    {
      provide: REDUCER_TOKEN,
      deps: [ReducersService],
      useFactory: getReducers
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
