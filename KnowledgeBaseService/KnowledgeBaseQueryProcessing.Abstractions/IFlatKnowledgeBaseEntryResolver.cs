using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public interface IFlatKnowledgeBaseEntryResolver
{
    public Task<Dictionary<string, FlatKnowledgeBaseEntry>> ResolveEntries(
        List<FlatKnowledgeBaseEntrySpec> entrySpecs,
        CancellationToken cancellationToken);
}