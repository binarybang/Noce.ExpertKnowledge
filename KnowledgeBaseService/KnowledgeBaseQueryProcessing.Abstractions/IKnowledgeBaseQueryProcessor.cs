using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public interface IKnowledgeBaseQueryProcessor
{
    Task<KnowledgeBaseQueryResult> QueryKnowledgeBase(
        KnowledgeBaseQuery query,
        CancellationToken cancellationToken);
}