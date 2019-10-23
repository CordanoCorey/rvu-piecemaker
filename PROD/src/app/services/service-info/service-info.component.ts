import { Component, OnInit } from '@angular/core';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Service } from '../services.model';
import { serviceSelector } from '../services.reducer';

@Component({
  selector: 'rvu-service-info',
  templateUrl: './service-info.component.html',
  styleUrls: ['./service-info.component.scss']
})
export class ServiceInfoComponent extends SmartComponent implements OnInit {
  service: Service = new Service();
  service$: Observable<Service>;
  constructor(public store: Store<any>) {
    super(store);
    this.service$ = serviceSelector(store);
  }

  ngOnInit() {
    this.sync(['service']);
  }
}
