import { Metadata, build, Collection } from '@caiu/library';

import { ExamType } from '../exam-types/exam-types.model';
import { BaseEntity } from '../shared/models';

export class Exam extends BaseEntity {
  id = 0;
  examTypeId = 0;
  notes = '';
  serviceId = 0;
  shiftId = 0;
  startTime: Date = new Date();
  endTime: Date = new Date();
  userId = 0;
  _examType: ExamType = new ExamType();
  _rvuTotal: number;

  static Build(data: Exam): Exam {
    return build(Exam, data, {
      examType: build(ExamType, data.examType),
      examTypeId: data.examTypeId,
      notes: data.notes,
      serviceId: data.serviceId,
      shiftId: data.shiftId
    });
  }

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', '_examType', '_rvuTotal', 'cptCode', 'examType', 'modalityName', 'name', 'rvuTotal', 'shift']
    });
  }

  set cptCode(value: string) {}

  get cptCode(): string {
    return this.examType.cptCode;
  }

  set examType(value: ExamType) {
    this._examType = value;
  }

  get examType(): ExamType {
    return build(ExamType, this._examType, {
      id: this.examTypeId
    });
  }

  set modalityName(value: string) {}

  get modalityName(): string {
    return this.examType.modalityName;
  }

  set name(value: string) {}

  get name(): string {
    return this.examType.name;
  }

  set rvuTotal(value: number) {
    this._rvuTotal = value;
  }

  get rvuTotal(): number {
    return this._rvuTotal || this.examType.rvuTotal;
  }
}

export class Exams extends Collection<Exam> {
  constructor() {
    super(Exam);
  }

  update(data: Exam | Exam[]): Exams {
    const exams = Array.isArray(data) ? data.map(x => Exam.Build(x)) : Exam.Build(data);
    return build(Exams, super.update(exams));
  }
}
