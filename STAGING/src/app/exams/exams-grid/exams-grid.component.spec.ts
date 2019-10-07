import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamsGridComponent } from './exams-grid.component';

describe('ExamsGridComponent', () => {
  let component: ExamsGridComponent;
  let fixture: ComponentFixture<ExamsGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExamsGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamsGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
