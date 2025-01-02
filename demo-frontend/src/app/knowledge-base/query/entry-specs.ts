import {EntryType, MarkdownKnowledgeEntry, TooltipKnowledgeEntry, UnsupportedEntry} from './entry-types';
import {
  KnowledgeBaseEntrySpecification,
  KnowledgeCompoundEntry,
  SubEntries
} from './entry-types';


export interface SimpleEntryOptions {
  entryKey?: string;
}

export const textEntry = (options: SimpleEntryOptions = {}): KnowledgeBaseEntrySpecification<string> => ({
  entryType: EntryType.PlainText,
  entryKey: options.entryKey,
});

export interface TextWithPlaceholdersEntryOptions<TReplacements extends Record<string, string> = Record<string, string>> {
  entryKey?: string;
  replacements: TReplacements;
}

export const textWithPlaceholdersEntry = <TReplacements extends Record<string, string>>(options: TextWithPlaceholdersEntryOptions<TReplacements>)
  : KnowledgeBaseEntrySpecification<string> => ({
  entryType: EntryType.TextWithPlaceholders,
  entryKey: options.entryKey,
  replacements: options.replacements
});

export const tooltipEntry = (options: SimpleEntryOptions = {}): KnowledgeBaseEntrySpecification<TooltipKnowledgeEntry> => ({
  entryType: EntryType.Tooltip,
  entryKey: options.entryKey,
});

export const markdownEntry = (options: SimpleEntryOptions = {}): KnowledgeBaseEntrySpecification<MarkdownKnowledgeEntry> => ({
  entryType: EntryType.Markdown,
  entryKey: options.entryKey,
});

export interface CompoundEntryOptions<T extends KnowledgeCompoundEntry> {
  entryKey?: string;
  subEntries: SubEntries<T>;
}

export const compoundEntry = <T extends KnowledgeCompoundEntry>(
  options: CompoundEntryOptions<T>): KnowledgeBaseEntrySpecification<T> => ({
  entryType: EntryType.Compound,
  subEntries: options.subEntries
});


export const unsupportedEntry = (options: SimpleEntryOptions = {}): KnowledgeBaseEntrySpecification<UnsupportedEntry> => ({
  entryType: EntryType.Unsupported,
  entryKey: options.entryKey,
});
