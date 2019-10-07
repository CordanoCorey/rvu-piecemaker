import { Collection, BaseEntity, build, Metadata } from '@caiu/library';

export class Goal extends BaseEntity {
  id = 0;
  dollarAmount = 0;
  rvuRate = 0;
  rvuTotalCompleted = 0;
  shiftHoursCompleted = 0;
  shiftHoursRemaining = 0;
  userId = 0;
  yearId = 0;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: [
        ...this.ignore,
        'id',
        'dollarAmountCompleted',
        'dollarAmountRemaining',
        'dollarsPerHourCompleted',
        'dollarsPerHourRemaining',
        'rvuRate',
        'rvuTotalCompleted',
        'rvuTotalRemaining',
        'rvuTotalPerHourCompleted',
        'rvuTotalPerHourRemaining',
        'shiftHoursCompleted',
        'shiftHoursRemaining'
      ]
    });
  }

  get dollarAmountCompleted(): number {
    return this.rvuTotalCompleted * this.rvuRate;
  }

  get dollarAmountRemaining(): number {
    return this.rvuTotalRemaining * this.rvuRate;
  }

  get dollarsPerHourCompleted(): number {
    return this.shiftHoursCompleted === 0 ? 0 : this.dollarAmountCompleted / this.shiftHoursCompleted;
  }

  get dollarsPerHourRemaining(): number {
    return this.shiftHoursRemaining === 0 ? 0 : this.dollarAmountRemaining / this.shiftHoursRemaining;
  }

  get rvuGoal(): number {
    return this.rvuRate === 0 ? 0 : this.dollarAmount / this.rvuRate;
  }

  get rvuTotalPerHourCompleted(): number {
    return this.shiftHoursCompleted === 0 ? 0 : this.rvuTotalCompleted / this.shiftHoursCompleted;
  }

  get rvuTotalPerHourRemaining(): number {
    return this.shiftHoursRemaining === 0 ? 0 : this.rvuTotalRemaining / this.shiftHoursRemaining;
  }

  get rvuTotalRemaining(): number {
    return this.rvuGoal - this.rvuTotalCompleted;
  }

  get totalShiftHours(): number {
    return this.shiftHoursCompleted + this.shiftHoursRemaining;
  }

  get rvuPerHourGoal(): number {
    return this.rvuGoal / this.totalShiftHours;
  }
}

export class Goals extends Collection<Goal> {
  constructor() {
    super(Goal);
  }

  update(data: Goal | Goal[]): Goals {
    return build(Goals, super.update(data));
  }
}
