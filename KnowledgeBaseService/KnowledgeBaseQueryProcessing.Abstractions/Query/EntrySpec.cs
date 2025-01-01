namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

public record EntrySpec(string? EntryKey, string EntrySpecKey)
{
    public string EntryKeyForResolution => EntryKey ?? EntrySpecKey;
    
    public sealed record Unsupported(string? EntryKey, string EntrySpecKey) : EntrySpec(EntryKey, EntrySpecKey);
    public sealed record PlainText(string? EntryKey, string EntrySpecKey) : EntrySpec(EntryKey, EntrySpecKey);
    public sealed record Tooltip(string? EntryKey, string EntrySpecKey) : EntrySpec(EntryKey, EntrySpecKey);
    public sealed record Markdown(string? EntryKey, string EntrySpecKey) : EntrySpec(EntryKey, EntrySpecKey);
    public sealed record CompoundEntry(
        string? EntryKey,
        string EntrySpecKey,
        Dictionary<string, EntrySpec> SubEntries) : EntrySpec(EntryKey, EntrySpecKey);
}