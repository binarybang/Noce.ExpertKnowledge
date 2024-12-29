import {Entries, KnowledgeBaseQueryResult} from "./knowledge-base-query";

export interface KnowledgeBaseRequest<TResponse extends KnowledgeBaseQueryResult> {
  entryKeyPrefix: string,
  entries: Entries<TResponse>;
}
