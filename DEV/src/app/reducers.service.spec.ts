import { TestBed } from '@angular/core/testing';

import { ReducersService } from './reducers.service';

describe('ReducersService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ReducersService = TestBed.get(ReducersService);
    expect(service).toBeTruthy();
  });
});
