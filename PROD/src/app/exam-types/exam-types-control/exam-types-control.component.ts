import { Component, OnInit, forwardRef, Input, ViewChild } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { MatCheckbox } from '@angular/material';
import { SmartComponent, HttpActions, toInt, truthy, build, compareNumbers } from '@caiu/library';
import { Store } from '@ngrx/store';
import { Observable, BehaviorSubject, combineLatest, Subscription } from 'rxjs';

import { ExamType, ExamTypeXref, ExamTypes } from '../exam-types.model';
import { examTypesSelector, ExamTypesActions } from '../exam-types.reducer';
import { Ordering } from 'src/app/shared/models';
import { map } from 'rxjs/operators';
import { CdkDragDrop } from '@angular/cdk/drag-drop';

export const EXAM_TYPES_CONTROL_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => ExamTypesControlComponent),
  multi: true
};

@Component({
  selector: 'rvu-exam-types-control',
  templateUrl: './exam-types-control.component.html',
  styleUrls: ['./exam-types-control.component.scss'],
  providers: [EXAM_TYPES_CONTROL_ACCESSOR]
})
export class ExamTypesControlComponent extends SmartComponent implements OnInit, ControlValueAccessor {
  @ViewChild('selectAllExamTypes', { static: false }) selectAllExamTypesCheckbox: MatCheckbox;
  @ViewChild('unselectAllExamTypes', { static: false }) unselectAllExamTypesCheckbox: MatCheckbox;
  private onModelChange: Function;
  private onTouch: Function;
  _value: ExamTypeXref[] = [];
  countSelected$: Observable<number>;
  examTypes: ExamType[] = [];
  examTypes$: Observable<ExamType[]>;
  filtered$: Observable<ExamTypeXref[]>;
  initialValueSubject = new BehaviorSubject<ExamTypeXref[]>([]);
  orderingSubject = new BehaviorSubject<Ordering<ExamTypeXref>>(new Ordering([], ExamTypeXref));
  searchTerm$: Observable<string>;
  searchTermSubject = new BehaviorSubject<string>('');
  _selectedExamTypes = {};
  selectedSubject = new BehaviorSubject<{ [id: number]: boolean }>({});
  value$: Observable<ExamTypeXref[]>;

  constructor(public store: Store<any>) {
    super(store);
    this.examTypes$ = examTypesSelector(store);
    this.searchTerm$ = this.searchTermSubject.asObservable();
    this.countSelected$ = this.selectedSubject.asObservable().pipe(map(x => Object.keys(x).reduce((acc, key) => (x[key] ? acc + 1 : acc), 0)));
    this.value$ = combineLatest(this.orderingSubject.asObservable(), this.selectedSubject.asObservable(), (ordering, selected) => {
      return ordering.items.filter(x => selected[x.examTypeId]).map((x, i) => build(ExamTypeXref, x, { order: i }));
    });
    this.filtered$ = combineLatest(this.orderingSubject.asObservable(), this.searchTermSubject.asObservable(), (ordering, term) => {
      return ordering.items
        .filter(x => x.examTypeName.toLowerCase().includes(term.toLowerCase()) || x.examTypeModality.toLowerCase().includes(term.toLowerCase()))
        .sort((a, b) => compareNumbers(a.order, b.order));
    });
  }

  get value(): ExamTypeXref[] {
    return this._value;
  }

  @Input()
  set value(value: ExamTypeXref[]) {
    this._value = value;
  }

  get dataChanges(): Subscription {
    return combineLatest(this.initialValueSubject.asObservable(), this.examTypes$, (value, types) => ({
      value,
      types
    })).subscribe(x => {
      this.selectedSubject.next(x.types.reduce((acc, type) => Object.assign({}, acc, { [type.id]: x.value.findIndex(y => y.examTypeId === type.id) !== -1 }), {}));
      this.orderingSubject.next(new Ordering(ExamTypes.ToXref(x.types, x.value), ExamTypeXref));
    });
  }

  registerOnChange(fn: Function) {
    this.onModelChange = fn;
  }

  registerOnTouched(fn: Function) {
    this.onTouch = fn;
  }

  writeValue(value: ExamTypeXref[]) {
    this.initialValueSubject.next(value);
  }

  onChange(value: ExamTypeXref[]) {
    this.value = value;
    if (this.onModelChange) {
      this.onModelChange(value);
    }
  }

  onBlur(e: any) {}

  get filtered(): boolean {
    return truthy(this.searchTermSubject.value);
  }

  ngOnInit() {
    this.sync(['examTypes']);
    this.addSubscription(this.dataChanges);
    this.value$.subscribe(x => {
      this.onChange(x);
    });
    this.getExamTypes();
  }

  clearSearchTerm() {
    this.searchTermSubject.next('');
  }

  filter() {
    const value = this.value;
    const all = ExamTypes.ToXref(this.examTypes, value);
    const items = value.length === this.orderingSubject.value.items.length ? all : value;
    this.orderingSubject.next(new Ordering(items, ExamTypeXref));
  }

  isSelected(id: number): boolean {
    return this.selectedSubject.value[id];
  }

  getExamTypes() {
    this.dispatch(HttpActions.get(`examtypes`, ExamTypesActions.GET));
  }

  onApplyToAll(e: boolean) {
    if (e) {
      this.selectAllExamTypes();
    } else {
      this.unselectAllExamTypes();
    }
  }

  reorder() {
    const value = this.value;
    const items = [...value, ...this.orderingSubject.value.items.filter(x => value.findIndex(y => y.examTypeId === x.examTypeId) === -1)];
    this.orderingSubject.next(new Ordering(items, ExamTypeXref));
  }

  reorderList(e: CdkDragDrop<any>) {
    console.dir(this.orderingSubject.value.items);
    this.orderingSubject.next(new Ordering(this.orderingSubject.value.move(e.item.data, e.currentIndex), ExamTypeXref));
    console.dir(this.orderingSubject.value.items);
  }

  selectAllExamTypes() {
    this.selectedSubject.next(Object.keys(this.selectedSubject.value).reduce((acc, key) => Object.assign({}, acc, { [key]: true }), {}));
    this.selectAllExamTypesCheckbox.checked = true;
    this.unselectAllExamTypesCheckbox.checked = false;
  }

  toggleExamType(e: ExamTypeXref) {
    this.selectedSubject.next(Object.assign({}, this.selectedSubject.value, { [e.examTypeId]: !this.isSelected(e.examTypeId) }));
  }

  unselectAllExamTypes() {
    this.selectedSubject.next(Object.keys(this.selectedSubject.value).reduce((acc, key) => Object.assign({}, acc, { [key]: false }), {}));
    this.unselectAllExamTypesCheckbox.checked = true;
    this.selectAllExamTypesCheckbox.checked = false;
  }
}
