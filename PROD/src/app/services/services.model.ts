import { build, Collection, Metadata } from '@caiu/library';

export class Service {
  id = 0;
  name = '';
  description = '';
  doctorTypeId = 0;
  parentId = 0;

  get metadata(): Metadata {
    return build(Metadata, {
      ignore: ['id', 'createdById', 'createdDate', 'lastModifiedById', 'lastModifiedDate', 'parentId', 'doctorTypeId']
    });
  }
}

export class Services extends Collection<Service> {
  constructor() {
    super(Service);
  }

  update(data: Service | Service[]): Services {
    return build(Services, super.update(data));
  }
}
