import { Component, OnInit, Input } from '@angular/core';

import { Shift } from '../../shifts/shifts.model';

@Component({
  selector: 'rvu-shift-recap',
  templateUrl: './shift-recap.component.html',
  styleUrls: ['./shift-recap.component.scss']
})
export class ShiftRecapComponent implements OnInit {
  @Input() shift: Shift = new Shift();

  constructor() {}

  ngOnInit() {}
}
