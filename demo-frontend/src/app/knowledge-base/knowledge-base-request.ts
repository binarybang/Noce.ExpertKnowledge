export type KnowledgeBaseQueryResult = {
  [key in string]: KnowledgeEntryContent;
}

type Entries<T extends KnowledgeBaseQueryResult> = {[K in keyof T]: KnowledgeBaseEntrySpecification<T[K]>};

export interface KnowledgeBaseRequest<TResponse extends KnowledgeBaseQueryResult> {
  entryKeyPrefix: string,
  entries: Entries<TResponse>;
}

export type TooltipKnowledgeEntry = {
  title: string;
  content: string;
}

export type MarkdownKnowledgeEntry = {
  markdownContent: string;
}

type KnowledgeCompoundEntry = {
  [key in string]: KnowledgeEntryContent;
}

type KnowledgeEntryContent = string | TooltipKnowledgeEntry | MarkdownKnowledgeEntry | KnowledgeCompoundEntry;

type SubEntries<T extends KnowledgeEntryContent> = T extends KnowledgeCompoundEntry ? Entries<T> : never;

export enum EntryType {
  PlainText = 1,
  Tooltip = 2,
  Markdown = 3,
  Compound = 4
}

export type KnowledgeBaseEntrySpecification<T extends KnowledgeEntryContent> = {
  entryKey?: string;
  entryType: EntryType,
  subEntries?: SubEntries<T>;
}

export const textEntry = (entryKey?: string): KnowledgeBaseEntrySpecification<string> => ({
  entryKey: entryKey,
  entryType: EntryType.PlainText,
});

export const tooltipEntry = (entryKey?: string): KnowledgeBaseEntrySpecification<TooltipKnowledgeEntry> => ({
  entryKey: entryKey,
  entryType: EntryType.Tooltip,
});

export const markdownEntry = (entryKey?: string): KnowledgeBaseEntrySpecification<MarkdownKnowledgeEntry> => ({
  entryKey: entryKey,
  entryType: EntryType.Markdown,
});

export const compoundEntry = <T extends KnowledgeCompoundEntry>(
  subEntries: SubEntries<T>): KnowledgeBaseEntrySpecification<T> => ({
  entryType: EntryType.Compound,
  subEntries
});

export const keyedCompoundEntry = <T extends KnowledgeCompoundEntry>(
  entryKey: string,
  subEntries: SubEntries<T>): KnowledgeBaseEntrySpecification<T> => ({
  entryKey,
  entryType: EntryType.Compound,
  subEntries
});
