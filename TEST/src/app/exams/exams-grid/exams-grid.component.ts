import { Component, OnInit, Input } from '@angular/core';

import { Exam } from '../exams.model';

@Component({
  selector: 'rvu-exams-grid',
  templateUrl: './exams-grid.component.html',
  styleUrls: ['./exams-grid.component.scss']
})
export class ExamsGridComponent implements OnInit {
  @Input() exams: Exam[] = [];

  constructor() {}

  get data(): any[] {
    return this.exams.reduce((acc, x) => {
      return [...acc, x];
    }, []);
  }

  get columnsToDisplay(): string[] {
    return this.displayedColumns.slice();
  }

  get displayedColumns(): string[] {
    return ['name', 'rvuTotal'];
  }

  ngOnInit() {}
}
