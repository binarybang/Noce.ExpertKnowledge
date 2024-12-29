import { ResolveFn } from '@angular/router';
import {KnowledgeBaseQueryResult, KnowledgeBaseRequest} from './knowledge-base-request';
import {KnowledgeBaseService} from './knowledge-base.service';
import {inject} from '@angular/core';

export const knowledgeBaseQueryResolver: ResolveFn<boolean> = (route, state) => {
  return true;
};

export const createKnowledgeBaseQueryResolver = <TData extends KnowledgeBaseQueryResult>(buildRequest: () => KnowledgeBaseRequest<TData>): ResolveFn<TData> => {
  return () => {
    const knowledgeBaseService = inject(KnowledgeBaseService);
    return knowledgeBaseService.queryKnowledgeBase(buildRequest());
  };
}
