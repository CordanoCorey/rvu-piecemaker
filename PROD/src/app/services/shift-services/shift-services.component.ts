import { Component, OnInit } from '@angular/core';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Service } from '../services.model';
import { shiftServicesSelector } from '../services.reducer';

@Component({
  selector: 'rvu-shift-services',
  templateUrl: './shift-services.component.html',
  styleUrls: ['./shift-services.component.scss']
})
export class ShiftServicesComponent extends SmartComponent implements OnInit {

  services: Service[] = [];
  services$: Observable<Service[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.services$ = shiftServicesSelector(store);
  }

  ngOnInit() {
  }

}
