using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public interface IEntrySpecDecoder
{
    Dictionary<string, KnowledgeBaseEntry> DecodeEntrySpecs(
        string entryKeyPrefix,
        Dictionary<string, EntrySpec> entrySpecs,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries);
}