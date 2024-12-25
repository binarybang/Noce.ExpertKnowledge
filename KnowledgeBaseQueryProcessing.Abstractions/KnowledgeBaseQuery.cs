namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public record KnowledgeBaseQuery
{
    public required string ElementPrefix { get; init; }
    public required Dictionary<string, EntrySpecification> Entries { get; init; }
}

public record EntrySpecification(string? EntryKey)
{
    
    public sealed record PlainText(string? EntryKey) : EntrySpecification(EntryKey);
    public sealed record Tooltip(string? EntryKey) : EntrySpecification(EntryKey);
    public sealed record Markdown(string? EntryKey) : EntrySpecification(EntryKey);
    public sealed record CompoundEntry(
        string? EntryKey,
        Dictionary<string, EntrySpecification> SubEntries) : EntrySpecification(EntryKey);
}

public record FlatKnowledgeBaseEntrySpecification(string EntryKey)
{
}

public record FlatKnowledgeBaseEntry(string EntryKey, string RawValue)
{
}