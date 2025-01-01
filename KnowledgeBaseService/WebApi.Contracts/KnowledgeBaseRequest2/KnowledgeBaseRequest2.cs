namespace Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest2;

public record KnowledgeBaseRequest2
{
    public required Dictionary<string, KnowledgeBaseEntrySpec2> Entries { get; init; }
}