import { Routes } from '@angular/router';
import {createKnowledgeBaseQueryResolver} from './knowledge-base/knowledge-base-query.resolver';
import {QueryResolutionDemoComponent} from './query-resolution-demo/query-resolution-demo.component';
import {buildPageDataSampleKnowledgeBaseQuery} from './knowledge-base-data-samples';

export const routes: Routes = [
  {
    path: 'query-resolution-demo',
    component: QueryResolutionDemoComponent,
    resolve: {
      pageDataSample: createKnowledgeBaseQueryResolver(buildPageDataSampleKnowledgeBaseQuery)
    }
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'query-resolution-demo',
  }
];
