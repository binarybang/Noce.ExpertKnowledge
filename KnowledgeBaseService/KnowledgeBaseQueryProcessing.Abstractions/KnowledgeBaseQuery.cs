namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public record KnowledgeBaseQuery
{
    public required string ElementPrefix { get; init; }
    public required Dictionary<string, EntrySpecification> Entries { get; init; }
}

public record EntrySpecification(string? EntryKey, string EntrySpecKey)
{
    public string EntryKeyForResolution => EntryKey ?? EntrySpecKey;
    
    public sealed record Unsupported(string? EntryKey, string EntrySpecKey) : EntrySpecification(EntryKey, EntrySpecKey);
    public sealed record PlainText(string? EntryKey, string EntrySpecKey) : EntrySpecification(EntryKey, EntrySpecKey);
    public sealed record Tooltip(string? EntryKey, string EntrySpecKey) : EntrySpecification(EntryKey, EntrySpecKey);
    public sealed record Markdown(string? EntryKey, string EntrySpecKey) : EntrySpecification(EntryKey, EntrySpecKey);
    public sealed record CompoundEntry(
        string? EntryKey,
        string EntrySpecKey,
        Dictionary<string, EntrySpecification> SubEntries) : EntrySpecification(EntryKey, EntrySpecKey);
}

public record FlatKnowledgeBaseEntrySpecification(string EntryKey)
{
}

public record FlatKnowledgeBaseEntry(string EntryKey, string RawValue)
{
}