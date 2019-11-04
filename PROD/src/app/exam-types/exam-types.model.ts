import { Metadata, build, Collection } from '@caiu/library';

import { BaseEntity } from '../shared/models';

export class ExamType extends BaseEntity {
  id = 0;
  cptCode = '';
  description = '';
  modalityId = 0;
  modalityName = '';
  name = '';
  order = 0;
  rvuTotal = 0;
  examGroupIds: number[] = [];

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['modalityName']
    });
  }
}

export class ExamTypeXref {
  id = 0;
  examGroupId = 0;
  examTypeId = 0;
  examTypeModality = '';
  examTypeName = '';
  order = null;
  serviceId = 0;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'examGroupId', 'serviceId']
    });
  }
}

export class ExamTypes extends Collection<ExamType> {
  static ToXref(examTypes: ExamType[], value: ExamTypeXref[]): ExamTypeXref[] {
    return examTypes.map((type, i) => {
      const existing = value.find(y => y.examTypeId === type.id);
      return build(ExamTypeXref, existing, {
        examTypeId: type.id,
        examTypeModality: type.modalityName,
        examTypeName: type.name,
        order: existing ? existing.order : value.length === 0 ? i : value.length
      });
    });
  }

  constructor() {
    super(ExamType);
  }

  update(data: ExamType | ExamType[]): ExamTypes {
    return build(ExamTypes, super.update(data));
  }
}

export class ExamTypeRow {
  count = 0;
  cptCode = '';
  examTypeId = 0;
  modalityName = '';
  name = '';
  rvuEach = 0;

  get rvuTotal(): number {
    return this.rvuEach * this.count;
  }
}
