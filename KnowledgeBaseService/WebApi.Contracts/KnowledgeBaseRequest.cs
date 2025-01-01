namespace Noce.ExpertKnowledge.WebApi.Contracts;

public record KnowledgeBaseRequest
{
    public required string EntryKeyPrefix { get; init; }
    public required Dictionary<string, KnowledgeBaseEntrySpec> Entries { get; init; }
}

public record KnowledgeBaseEntrySpec
{
    public required EntryType EntryType { get; init; }
    public string? EntryKey { get; init; }
    public Dictionary<string, KnowledgeBaseEntrySpec>? SubEntries { get; init; } = new();
}

public enum EntryType
{
    PlainText = 1,
    Tooltip = 2,
    Markdown = 3,
    Compound = 4,
    TextWithPlaceholders = 5
};