namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public interface IKnowledgeBaseQueryProcessor
{
    Task<KnowledgeBaseQueryResult> QueryKnowledgeBase(
        KnowledgeBaseQuery query,
        CancellationToken cancellationToken);
}