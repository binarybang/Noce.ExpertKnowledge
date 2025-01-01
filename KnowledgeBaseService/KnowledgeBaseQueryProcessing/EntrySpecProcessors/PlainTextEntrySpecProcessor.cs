using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public class PlainTextEntrySpecProcessor : IEntrySpecProcessor<EntrySpec.PlainText>
{
    public List<FlatKnowledgeBaseEntrySpec> Encode(EntrySpec.PlainText entrySpec, string fullEntryKey)
    {
        return [new FlatKnowledgeBaseEntrySpec(fullEntryKey)];
    }

    public KnowledgeBaseEntry Decode(
        EntrySpec.PlainText entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        return new KnowledgeBaseEntry.PlainText(resolvedFlatEntries.GetRawValueOrEmpty(fullEntryKey));
    }
}