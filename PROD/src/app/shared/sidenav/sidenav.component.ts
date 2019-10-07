import { Component, OnInit, Input } from '@angular/core';
import {
  urlSelector,
  SmartComponent,
  windowHeightSelector,
  sidenavOpenedSelector,
  SidenavActions,
  windowWidthSelector
} from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, Subscription, of } from 'rxjs';
import { CurrentUserActions } from '../actions';

@Component({
  selector: 'rvu-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent extends SmartComponent implements OnInit {
  @Input() isMobile = false;
  dashboardUrl = '/dashboard';
  isDarkTheme$: Observable<boolean>;
  opened = true;
  opened$: Observable<boolean>;
  url$: Observable<string>;
  windowHeight = 0;
  windowHeight$: Observable<number>;
  windowWidth = 0;
  windowWidth$: Observable<number>;
  _url = '/';

  constructor(public store: Store<any>) {
    super(store);
    this.isDarkTheme$ = of(true);
    this.opened$ = sidenavOpenedSelector(store);
    this.url$ = urlSelector(store);
    this.windowHeight$ = windowHeightSelector(store);
    this.windowWidth$ = windowWidthSelector(store);
  }

  get atRoot(): boolean {
    return this.url === '/';
  }

  get onDashboard(): boolean {
    return this.url.startsWith(this.dashboardUrl);
  }

  get display(): 'block' | 'none' {
    return this.opened ? 'block' : 'none';
  }

  get miniDisplay(): 'block' | 'none' {
    return this.opened ? 'none' : 'block';
  }

  get shouldCloseSidebar(): boolean {
    return !this.atRoot && !this.onDashboard;
  }

  get shouldOpenSidebar(): boolean {
    return this.atRoot || this.onDashboard;
  }
  get sidenavWidth(): number {
    return this.opened ? (this.isMobile ? this.windowWidth : 135) : 0;
  }

  set url(value: string) {
    this._url = value;
    this.refresh();
  }

  get url(): string {
    return this._url;
  }

  ngOnInit() {
    this.sync(['opened', 'url', 'windowHeight', 'windowWidth']);
  }

  refresh() {
    setTimeout(() => {
      if (this.shouldOpenSidebar) {
        this.openSidenav();
      } else if (this.shouldCloseSidebar) {
        this.closeSidenav();
      }
    }, 0);
  }

  closeSidenav() {
    this.dispatch(SidenavActions.close());
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

  openSidenav() {
    this.dispatch(SidenavActions.open());
  }

  toggleSidenav() {
    this.dispatch(SidenavActions.toggle());
  }
}
