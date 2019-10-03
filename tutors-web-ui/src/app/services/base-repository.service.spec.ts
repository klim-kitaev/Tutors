import { TestBed } from '@angular/core/testing';

import { BaseRepositoryService } from './base-repository.service';

describe('BaseRepositoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BaseRepositoryService = TestBed.get(BaseRepositoryService);
    expect(service).toBeTruthy();
  });
});
