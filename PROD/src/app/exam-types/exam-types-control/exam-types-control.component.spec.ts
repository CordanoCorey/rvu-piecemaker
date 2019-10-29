import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamTypesControlComponent } from './exam-types-control.component';

describe('ExamTypesControlComponent', () => {
  let component: ExamTypesControlComponent;
  let fixture: ComponentFixture<ExamTypesControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExamTypesControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamTypesControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
