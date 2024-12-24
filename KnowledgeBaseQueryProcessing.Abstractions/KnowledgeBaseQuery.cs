namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public record KnowledgeBaseQuery
{
    public required string ElementPrefix { get; init; }
    public required Dictionary<string, EntrySpecification> Entries { get; init; }
}

public record EntrySpecification
{
    public required string ElementKey { get; init; }
    
    public sealed record PlainText() : EntrySpecification;
    public sealed record Tooltip() : EntrySpecification;
    public sealed record Markdown() : EntrySpecification;
    public sealed record CompoundEntry(Dictionary<string, EntrySpecification> SubEntries) : EntrySpecification;
}

public record FlatKnowledgeBaseEntrySpecification(string EntryKey)
{
}

public record FlatKnowledgeBaseEntry(string EntryKey, string RawValue)
{
}