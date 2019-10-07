import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftProgressComponent } from './shift-progress.component';

describe('ShiftProgressComponent', () => {
  let component: ShiftProgressComponent;
  let fixture: ComponentFixture<ShiftProgressComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftProgressComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
