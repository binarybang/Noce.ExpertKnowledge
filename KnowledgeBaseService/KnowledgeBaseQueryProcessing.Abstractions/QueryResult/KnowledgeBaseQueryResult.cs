namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

public class KnowledgeBaseQueryResult
{
    public required Dictionary<string, KnowledgeBaseEntry> Entries { get; init; }
}