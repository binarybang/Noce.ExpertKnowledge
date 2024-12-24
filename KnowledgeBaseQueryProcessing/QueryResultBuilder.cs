using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal class QueryResultBuilder : IQueryResultBuilder
{
    private readonly IEntrySpecificationsDecoder _entrySpecificationsDecoder;

    public QueryResultBuilder(IEntrySpecificationsDecoder entrySpecificationsDecoder)
    {
        _entrySpecificationsDecoder = entrySpecificationsDecoder;
    }

    public KnowledgeBaseQueryResult BuildQueryResult(
        KnowledgeBaseQuery query,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var entries = _entrySpecificationsDecoder.DecodeEntrySpecifications(query.ElementPrefix, query.Entries, resolvedFlatEntries);
        return new KnowledgeBaseQueryResult
        {
            Entries = entries
        };
    }
    
}