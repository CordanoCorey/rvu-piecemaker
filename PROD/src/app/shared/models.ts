import { Metadata, build, Validators, BaseEntity, Collection, CurrentUser as BaseCurrentUser } from '@caiu/library';

export { BaseEntity } from '@caiu/library';

export class Login {
  email = '';
  password = '';

  get metadata(): Metadata {
    return build(Metadata, {
      email: {
        validators: [Validators.required, Validators.email]
      }
    });
  }
}

export class Tab extends BaseEntity {
  label = '';
  routerLink = '';
}

export class Tabs extends Collection<Tab> {
  constructor() {
    super(Tab);
  }
}

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

export class CurrentUser extends BaseCurrentUser {
  isAdmin = false;
  rvuRate = 0;
  static Build(data: any): CurrentUser {
    return build(CurrentUser, BaseCurrentUser.Build(data));
  }
}
