import { BaseEntity, Collection, build, Metadata } from '@caiu/library';

import { ExamTypeXref } from '../exam-types/exam-types.model';

export class ExamGroup extends BaseEntity {
  id = 0;
  name = '';
  description = '';
  examTypes: ExamTypeXref[] = [];

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id']
    });
  }
}

export class ExamGroups extends Collection<ExamGroup> {
  constructor() {
    super(ExamGroup);
  }

  update(data: ExamGroup | ExamGroup[]): ExamGroups {
    return build(ExamGroups, super.update(data));
  }
}
