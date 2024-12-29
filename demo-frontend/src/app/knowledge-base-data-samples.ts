﻿import {
  compoundEntry,
  markdownEntry, MarkdownKnowledgeEntry,
  textEntry,
  tooltipEntry, TooltipKnowledgeEntry, unsupportedEntry, UnsupportedEntry
} from './knowledge-base/knowledge-base-query';
import {KnowledgeBaseRequest} from './knowledge-base/knowledge-base-request';

export type PageDataSample = {
  personalDataHeader: string;
  personalIdTooltip: TooltipKnowledgeEntry;
  detailedExplanation: MarkdownKnowledgeEntry;
}

export function buildPageDataSampleKnowledgeBaseQuery(): KnowledgeBaseRequest<PageDataSample> {
  return {
    entryKeyPrefix: 'product.pageDataSample',
    entries: {
      personalDataHeader: textEntry(),
      personalIdTooltip: tooltipEntry(),
      detailedExplanation: markdownEntry()
    }
  }
}

export type SecondDataSample = {
  sectionTitle: string;
  categories: {
    newCustomer: string;
    existingCustomer: string;
  }
}

export function buildSecondDataSampleKnowledgeBaseQuery(): KnowledgeBaseRequest<SecondDataSample> {
  return {
    entryKeyPrefix: 'product.secondDataSample',
    entries: {
      sectionTitle: textEntry(),
      categories: compoundEntry({
        newCustomer: textEntry(),
        existingCustomer: textEntry()
      })
    }
  }
}


export type BadDataSample = {
  noDataDemo: TooltipKnowledgeEntry;
  unsupportedEntry: UnsupportedEntry;
}

export function buildBadDataSampleKnowledgeBaseQuery(): KnowledgeBaseRequest<BadDataSample> {
  return {
    entryKeyPrefix: 'product.badData',
    entries: {
      noDataDemo: tooltipEntry('missingEntry'),
      unsupportedEntry: unsupportedEntry()
    }
  }
}
