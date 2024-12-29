import { TestBed } from '@angular/core/testing';

import { KnowledgeBaseRequestBuilderService } from './knowledge-base-request-builder.service';

describe('KnowledgeBaseRequestBuilderService', () => {
  let service: KnowledgeBaseRequestBuilderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KnowledgeBaseRequestBuilderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
