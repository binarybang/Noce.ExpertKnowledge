using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal class KnowledgeBaseQueryProcessor : IKnowledgeBaseQueryProcessor
{
    private readonly IEntrySpecificationsEncoder _entrySpecificationsEncoder;
    private readonly IFlatKnowledgeBaseEntryResolver _flatKnowledgeBaseEntryResolver;
    private readonly IQueryResultBuilder _queryResultBuilder;

    public KnowledgeBaseQueryProcessor(
        IEntrySpecificationsEncoder entrySpecificationsEncoder,
        IFlatKnowledgeBaseEntryResolver flatKnowledgeBaseEntryResolver,
        IQueryResultBuilder queryResultBuilder)
    {
        _flatKnowledgeBaseEntryResolver = flatKnowledgeBaseEntryResolver;
        _queryResultBuilder = queryResultBuilder;
        _entrySpecificationsEncoder = entrySpecificationsEncoder;
    }

    public async Task<KnowledgeBaseQueryResult> QueryKnowledgeBase(
        KnowledgeBaseQuery query,
        CancellationToken cancellationToken)
    {
        var flatEntries = _entrySpecificationsEncoder.EncodeEntrySpecifications(query.ElementPrefix, query.Entries);
        var resolvedFlatEntries = await _flatKnowledgeBaseEntryResolver.ResolveEntries(flatEntries.ToList(), cancellationToken);
        return _queryResultBuilder.BuildQueryResult(query, resolvedFlatEntries);
    }
}