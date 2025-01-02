import {
  compoundEntry,
  markdownEntry,
  textEntry,
  tooltipEntry, UnsupportedEntry,
  unsupportedEntry,
  MarkdownKnowledgeEntry,
  TooltipKnowledgeEntry, textWithPlaceholdersEntry
} from './knowledge-base/query';
import {KnowledgeBaseRequest} from './knowledge-base/knowledge-base-request';

export type PageDataSample = {
  personalDataHeader: string;
  personalIdTooltip: TooltipKnowledgeEntry;
  detailedExplanation: MarkdownKnowledgeEntry;
  placeholderEntry: string;
}

export function buildPageDataSampleKnowledgeBaseQuery(): KnowledgeBaseRequest<PageDataSample> {
  return {
    entryKeyPrefix: 'product.pageDataSample',
    entries: {
      personalDataHeader: textEntry(),
      personalIdTooltip: tooltipEntry(),
      detailedExplanation: markdownEntry(),
      placeholderEntry: textWithPlaceholdersEntry({
        replacements: {
          placeholder: "REPLACED"
        }
      })
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
        subEntries: {
          newCustomer: textEntry(),
          existingCustomer: textEntry()
        }
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
      noDataDemo: tooltipEntry({entryKey: 'missingEntry'}),
      unsupportedEntry: unsupportedEntry()
    }
  }
}
