import {Component, inject} from '@angular/core';
import {KnowledgeBaseService} from '../knowledge-base/knowledge-base.service';
import {map, Observable} from 'rxjs';
import {
  buildSecondDataSampleKnowledgeBaseQuery,
  PageDataSample,
  SecondDataSample
} from '../knowledge-base-data-samples';
import {ActivatedRoute} from '@angular/router';
import {AsyncPipe} from '@angular/common';
import {PrettyJsonPipe} from '../utils/pretty-json.pipe';

@Component({
  selector: 'app-query-resolution-demo',
  imports: [
    AsyncPipe,
    PrettyJsonPipe
  ],
  templateUrl: './query-resolution-demo.component.html',
  styleUrl: './query-resolution-demo.component.scss'
})
export class QueryResolutionDemoComponent {
  private readonly knowledgeBaseService: KnowledgeBaseService = inject(KnowledgeBaseService);
  private readonly activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  protected readonly pageDataSample$: Observable<PageDataSample> = this.activatedRoute.data.pipe(map(d => d['pageDataSample']));
  protected readonly secondSample$: Observable<SecondDataSample> = this.knowledgeBaseService.queryKnowledgeBase(buildSecondDataSampleKnowledgeBaseQuery());
}
