namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

public record KnowledgeBaseQuery
{
    public required string ElementPrefix { get; init; }
    public required Dictionary<string, EntrySpec> Entries { get; init; }
}