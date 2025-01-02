import {Entries, KnowledgeBaseQueryResult} from './query';

export interface KnowledgeBaseRequest<TResponse extends KnowledgeBaseQueryResult> {
  entryKeyPrefix: string,
  entries: Entries<TResponse>;
}
