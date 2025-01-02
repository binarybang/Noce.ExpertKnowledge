namespace Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest;

public record KnowledgeBaseRequest
{
    public string? EntryKeyPrefix { get; init; }
    public required Dictionary<string, KnowledgeBaseEntrySpec> Entries { get; init; }
}