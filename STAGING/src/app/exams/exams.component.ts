import { Component, OnInit } from '@angular/core';
import { SmartComponent } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Exam } from './exams.model';

@Component({
  selector: 'rvu-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.scss']
})
export class ExamsComponent extends SmartComponent implements OnInit {
  exams$: Observable<Exam[]>;

  constructor(public store: Store<any>) {
    super(store);
  }

  ngOnInit() {}
}
