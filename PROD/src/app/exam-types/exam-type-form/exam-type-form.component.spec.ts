import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamTypeFormComponent } from './exam-type-form.component';

describe('ExamTypeFormComponent', () => {
  let component: ExamTypeFormComponent;
  let fixture: ComponentFixture<ExamTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExamTypeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
