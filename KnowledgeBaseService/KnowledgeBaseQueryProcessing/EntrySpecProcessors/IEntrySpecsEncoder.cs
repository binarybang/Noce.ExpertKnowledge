using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public interface IEntrySpecsEncoder
{
    IEnumerable<FlatKnowledgeBaseEntrySpec> EncodeEntrySpecs(
        string entryKeyPrefix, Dictionary<string, EntrySpec> entrySpecs);
}