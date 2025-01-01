using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal class KnowledgeBaseQueryProcessor : IKnowledgeBaseQueryProcessor
{
    private readonly IEntrySpecsEncoder _entrySpecsEncoder;
    private readonly IFlatKnowledgeBaseEntryResolver _flatKnowledgeBaseEntryResolver;
    private readonly IQueryResultBuilder _queryResultBuilder;

    public KnowledgeBaseQueryProcessor(
        IEntrySpecsEncoder entrySpecsEncoder,
        IFlatKnowledgeBaseEntryResolver flatKnowledgeBaseEntryResolver,
        IQueryResultBuilder queryResultBuilder)
    {
        _flatKnowledgeBaseEntryResolver = flatKnowledgeBaseEntryResolver;
        _queryResultBuilder = queryResultBuilder;
        _entrySpecsEncoder = entrySpecsEncoder;
    }

    public async Task<KnowledgeBaseQueryResult> QueryKnowledgeBase(
        KnowledgeBaseQuery query,
        CancellationToken cancellationToken)
    {
        var flatEntries = _entrySpecsEncoder.EncodeEntrySpecs(query.ElementPrefix, query.Entries);
        var resolvedFlatEntries = await _flatKnowledgeBaseEntryResolver.ResolveEntries(flatEntries.ToList(), cancellationToken);
        return _queryResultBuilder.BuildQueryResult(query, resolvedFlatEntries);
    }
}