using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

public interface IQueryResultBuilder
{
    KnowledgeBaseQueryResult BuildQueryResult(
        KnowledgeBaseQuery query,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries);
}