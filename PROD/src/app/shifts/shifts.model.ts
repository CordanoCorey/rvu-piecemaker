import { BaseEntity } from '../shared/models';
import { Collection, Metadata, build, DateHelper, compareDates, roundToDecimalPlace } from '@caiu/library';

import { Exam } from '../exams/exams.model';

export class Shift extends BaseEntity {
  id = 0;
  exams: Exam[] = [];
  shiftTypeId = 0;
  rvuRate = 0;
  rvuTotal = 0;
  totalHours = 0;
  userId = 0;
  _endTime: Date = null;
  _startTime: Date = null;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['_endTime', '_startTime', '_id', 'id', 'isDefault', 'shiftLength']
    });
  }

  set endTime(value: Date) {
    this._endTime = value;
  }

  get endTime() {
    if (this._endTime) {
      return new Date(this._endTime);
    }
    return null;
  }

  get isDefault(): boolean {
    return this.id === 0;
  }

  get rvuCount(): number {
    return roundToDecimalPlace(this.exams.reduce((acc, x) => acc + x.rvuTotal, 0), 2);
  }

  get shiftLength() {
    return DateHelper.TimeBetween(this.startTime, this.endTime);
  }

  set startTime(value: Date) {
    this._startTime = value;
  }

  get startTime() {
    if (this._startTime) {
      return new Date(this._startTime);
    }
    return null;
  }

  get startTimestamp(): number {
    return this.startTime && this.startTime.getTime() ? this.startTime.getTime() : 0;
  }

  serialize() {
    return {
      id: this.id,
      shiftTypeId: this.shiftTypeId,
      userId: this.userId,
      startTime: new Date(this.startTime).toLocaleString('en-US', { timeZone: 'America/New_York' }),
      endTime: new Date(this.endTime).toLocaleString('en-US', { timeZone: 'America/New_York' }),
      rvuRate: this.rvuRate,
      rvuTotal: this.rvuTotal
    };
  }
}

export class Shifts extends Collection<Shift> {
  constructor() {
    super(Shift, 'startTimestamp');
  }

  get activeShiftId(): number {
    return this.getActiveShiftIdAtTime(new Date());
  }

  get activeShiftTimestamp(): number {
    const shift = this.asArray.find(x => x.startTime !== null && DateHelper.IsBetween(new Date(), x.startTime, x.endTime));
    return shift ? build(Shift, shift).startTimestamp : null;
  }

  get lastShiftId(): number {
    return this.getLastShiftIdAtTime(new Date());
  }

  get nextShiftId(): number {
    return this.getNextShiftIdAtTime(new Date());
  }

  getActiveShiftIdAtTime(d: Date): number {
    const shift = this.asArray.find(x => x.startTime !== null && DateHelper.IsBetween(d, x.startTime, x.endTime));
    return shift ? build(Shift, shift).id : null;
  }

  getLastShiftIdAtTime(d: Date): number {
    const ordered = this.asArray.filter(x => x.startTime < d && !DateHelper.IsBetween(d, x.startTime, x.endTime)).sort((a, b) => compareDates(a.startTime, b.startTime));
    return build(Shift, ordered.find((x, i) => i === 0)).id;
  }

  getNextShiftIdAtTime(d: Date): number {
    const ordered = this.asArray
      .filter(x => x.startTime > d && !DateHelper.IsBetween(d, x.startTime, x.endTime))
      .sort((a, b) => compareDates(a.startTime, b.startTime))
      .reverse();
    return build(Shift, ordered.find((x, i) => i === 0)).id;
  }

  get(startTimestamp: number): Shift {
    return build(Shift, super.get(startTimestamp));
  }

  update(data: Shift | Shift[]): Shifts {
    const shifts = Array.isArray(data) ? data.map(x => build(Shift, x)) : build(Shift, data);
    return build(Shifts, super.update(shifts));
  }
}
