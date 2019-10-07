import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'rvu-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.scss']
})
export class ProgressBarComponent implements OnInit {
  @Input() startLabel = '0800';
  @Input() progressLabel = '1105';
  @Input() endLabel = '1700';
  @Input() percentFilled = 50;
  @Input() primary = true;

  constructor() {}

  ngOnInit() {}
}
