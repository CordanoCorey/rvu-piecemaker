import { BaseEntity, Collection, build } from '@caiu/library';

export class ExamGroup extends BaseEntity {
  id = 0;
  name = 0;
  description = '';
}

export class ExamGroups extends Collection<ExamGroup> {
  constructor() {
    super(ExamGroup);
  }

  update(data: ExamGroup | ExamGroup[]): ExamGroups {
    return build(ExamGroups, super.update(data));
  }
}
