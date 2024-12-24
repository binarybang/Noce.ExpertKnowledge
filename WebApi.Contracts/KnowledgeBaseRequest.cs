namespace Noce.ExpertKnowledge.WebApi.Contracts;

public record KnowledgeBaseRequest
{
    public required string QueryKey { get; init; }
    public required string ElementPrefix { get; init; }
    public required Dictionary<string, KnowledgeBaseEntrySpecification> EntrySpecifications { get; init; }
}

public record KnowledgeBaseEntrySpecification
{
    public required string EntryKey { get; init; }
    public required EntryType EntryType { get; init; }
    public Dictionary<string, string> EntryProperties { get; init; } = new();
}

public enum EntryType
{
    PlainText = 1,
    Tooltip = 2,
    Markdown = 3
};