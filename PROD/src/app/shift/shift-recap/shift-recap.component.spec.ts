import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftRecapComponent } from './shift-recap.component';

describe('ShiftRecapComponent', () => {
  let component: ShiftRecapComponent;
  let fixture: ComponentFixture<ShiftRecapComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftRecapComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftRecapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
