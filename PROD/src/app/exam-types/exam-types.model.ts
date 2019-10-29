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

export class ExamTypes extends Collection<ExamType> {
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

export class ExamTypeXref {
  id = 0;
  examGroupId = 0;
  examTypeId = 0;
  examTypeModality = '';
  examTypeName = '';
  order = 0;
  serviceId = 0;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'examGroupId', 'serviceId']
    });
  }
}
