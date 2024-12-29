import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { knowledgeBaseQueryResolver } from './knowledge-base-query.resolver';

describe('knowledgeBaseQueryResolver', () => {
  const executeResolver: ResolveFn<boolean> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => knowledgeBaseQueryResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
