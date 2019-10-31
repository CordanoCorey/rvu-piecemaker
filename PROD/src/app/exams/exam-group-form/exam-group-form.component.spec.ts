import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamGroupFormComponent } from './exam-group-form.component';

describe('ExamGroupFormComponent', () => {
  let component: ExamGroupFormComponent;
  let fixture: ComponentFixture<ExamGroupFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExamGroupFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamGroupFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
