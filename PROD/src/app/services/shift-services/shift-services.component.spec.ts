import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftServicesComponent } from './shift-services.component';

describe('ShiftServicesComponent', () => {
  let component: ShiftServicesComponent;
  let fixture: ComponentFixture<ShiftServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
