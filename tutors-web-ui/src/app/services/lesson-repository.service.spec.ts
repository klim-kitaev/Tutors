import { TestBed } from '@angular/core/testing';

import { LessonRepositoryService } from './lesson-repository.service';

describe('LessonRepositoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LessonRepositoryService = TestBed.get(LessonRepositoryService);
    expect(service).toBeTruthy();
  });
});
