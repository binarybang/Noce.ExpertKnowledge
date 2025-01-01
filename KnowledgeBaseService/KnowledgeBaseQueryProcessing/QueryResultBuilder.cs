using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal class QueryResultBuilder : IQueryResultBuilder
{
    private readonly IEntrySpecDecoder _entrySpecDecoder;

    public QueryResultBuilder(IEntrySpecDecoder entrySpecDecoder)
    {
        _entrySpecDecoder = entrySpecDecoder;
    }

    public KnowledgeBaseQueryResult BuildQueryResult(
        KnowledgeBaseQuery query,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var entries = _entrySpecDecoder.DecodeEntrySpecs(query.ElementPrefix, query.Entries, resolvedFlatEntries);
        return new KnowledgeBaseQueryResult
        {
            Entries = entries
        };
    }
    
}