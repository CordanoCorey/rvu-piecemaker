import { build, LookupValue } from '@caiu/library';

export const SHIFT_STATUS = [
  build(LookupValue, { id: 0, name: 'PENDING' }),
  build(LookupValue, { id: 1, name: 'ACTIVE' }),
  build(LookupValue, { id: 2, name: 'ENDED' }),
  build(LookupValue, { id: 3, name: 'UPCOMING' })
];
