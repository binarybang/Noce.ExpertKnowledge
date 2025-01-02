import {inject, Injectable} from '@angular/core';
import {KnowledgeBaseRequest} from './knowledge-base-request';
import {map, Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {KnowledgeBaseResponse} from './knowledge-base-response';
import {API_URL_BUILDER, ApiUrlBuilder} from '../utils/api.config';
import {KnowledgeBaseQueryResult} from './query';

@Injectable({
  providedIn: 'root'
})
export class KnowledgeBaseService {
  private readonly httpClient: HttpClient = inject(HttpClient);
  private readonly apiUrlBuilder: ApiUrlBuilder = inject(API_URL_BUILDER);


  queryKnowledgeBase<TData extends KnowledgeBaseQueryResult>(query: KnowledgeBaseRequest<TData>): Observable<TData> {
    return this.httpClient
      .post<KnowledgeBaseResponse<TData>>(this.apiUrlBuilder('knowledge-base/query'), query)
      .pipe(map(r => r.entries));
  }
}
