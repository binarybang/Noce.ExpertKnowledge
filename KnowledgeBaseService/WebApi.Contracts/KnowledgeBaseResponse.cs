namespace Noce.ExpertKnowledge.WebApi.Contracts;

public record KnowledgeBaseResponse
{
    public required Dictionary<string, object?> Entries { get; init; }
}