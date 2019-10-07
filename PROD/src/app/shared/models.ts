import { Metadata, build, Validators, BaseEntity, Collection, CurrentUser as BaseCurrentUser } from '@caiu/library';
import { state } from '@angular/animations';

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

export class Service {
  id = 0;
  name = '';
  description = '';
  doctorTypeId = 0;
  parentId = 0;
}

export class Services extends Collection<Service> {
  constructor() {
    super(Service);
  }

  update(data: Service | Service[]): Services {
    return build(Services, super.update(data));
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

export class Tag extends BaseEntity {
  id = 0;
  name = 0;
  description = '';
}

export class Tags extends Collection<Tag> {
  constructor() {
    super(Tag);
  }

  update(data: Tag | Tag[]): Tags {
    return build(Tags, super.update(data));
  }
}

export class CurrentUser extends BaseCurrentUser {
  isAdmin = false;
  rvuRate = 0;
  static Build(data: any): CurrentUser {
    return build(CurrentUser, BaseCurrentUser.Build(data));
  }
}
