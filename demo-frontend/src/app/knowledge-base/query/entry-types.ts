export type KnowledgeBaseQueryResult = {
  [key in string]: KnowledgeEntryContent;
}

export type Entries<T extends KnowledgeBaseQueryResult> = {[K in keyof T]: KnowledgeBaseEntrySpecification<T[K]>};

export type TooltipKnowledgeEntry = {
  title: string;
  content: string;
}

export type MarkdownKnowledgeEntry = {
  markdownContent: string;
}

export type KnowledgeCompoundEntry = {
  [key in string]: KnowledgeEntryContent;
}

export type TextWithPlaceholdersEntry = string;

export type UnsupportedEntry = {
  unsafeData: string;
}

export type KnowledgeEntryContent = string | TooltipKnowledgeEntry | MarkdownKnowledgeEntry | KnowledgeCompoundEntry;

export type Replacements<T extends KnowledgeEntryContent> = T extends TextWithPlaceholdersEntry ? Record<string, string> : never;

export type SubEntries<T extends KnowledgeEntryContent> = T extends KnowledgeCompoundEntry ? Entries<T> : never;

export enum EntryType {
  PlainText = 1,
  Tooltip = 2,
  Markdown = 3,
  Compound = 4,
  TextWithPlaceholders = 5,
  Unsupported = 99,
}

export type KnowledgeBaseEntrySpecification<T extends KnowledgeEntryContent> = {
  entryType: EntryType,
  entryKey?: string;
  replacements?: Replacements<T>;
  subEntries?: SubEntries<T>;
}
