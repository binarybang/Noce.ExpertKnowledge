namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

public record EntrySpec(string EntryKey)
{
    public sealed record Unsupported(string EntryKey) : EntrySpec(EntryKey);
    public sealed record PlainText(string EntryKey) : EntrySpec(EntryKey);
    public sealed record TextWithPlaceholders(string EntryKey, Dictionary<string, string> Replacements) : EntrySpec(EntryKey);
    public sealed record Tooltip(string EntryKey) : EntrySpec(EntryKey);
    public sealed record Markdown(string EntryKey) : EntrySpec(EntryKey);
    public sealed record CompoundEntry(
        string EntryKey,
        Dictionary<string, EntrySpec> SubEntries) : EntrySpec(EntryKey);
}