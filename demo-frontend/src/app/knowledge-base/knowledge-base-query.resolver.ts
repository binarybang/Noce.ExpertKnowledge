import { ResolveFn } from '@angular/router';
import {KnowledgeBaseRequest} from './knowledge-base-request';
import {KnowledgeBaseService} from './knowledge-base.service';
import {inject} from '@angular/core';
import {KnowledgeBaseQueryResult} from './knowledge-base-query';

export const createKnowledgeBaseQueryResolver = <TData extends KnowledgeBaseQueryResult>(
  buildRequest: () => KnowledgeBaseRequest<TData>): ResolveFn<TData> => {
  return () => {
    const knowledgeBaseService = inject(KnowledgeBaseService);
    return knowledgeBaseService.queryKnowledgeBase(buildRequest());
  };
}
