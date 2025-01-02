namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

public record KnowledgeBaseQuery
{
    public required string EntryKeyPrefix { get; init; }
    public required Dictionary<string, EntrySpec> Entries { get; init; }
}