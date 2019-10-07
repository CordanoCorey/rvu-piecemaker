import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShiftTypesComponent } from './shift-types.component';

describe('ShiftTypesComponent', () => {
  let component: ShiftTypesComponent;
  let fixture: ComponentFixture<ShiftTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShiftTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShiftTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
