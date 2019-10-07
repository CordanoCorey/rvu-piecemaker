import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftTypeFormComponent } from './shift-type-form.component';

describe('ShiftTypeFormComponent', () => {
  let component: ShiftTypeFormComponent;
  let fixture: ComponentFixture<ShiftTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftTypeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
