import { TestBed } from '@angular/core/testing';

import { PupilRepositoryService } from './pupil-repository.service';

describe('PupilRepositoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PupilRepositoryService = TestBed.get(PupilRepositoryService);
    expect(service).toBeTruthy();
  });
});
