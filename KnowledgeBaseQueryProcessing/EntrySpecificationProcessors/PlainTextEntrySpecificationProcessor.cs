using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public class PlainTextEntrySpecificationProcessor : IEntrySpecificationProcessor<EntrySpecification.PlainText>
{
    public List<FlatKnowledgeBaseEntrySpecification> Encode(EntrySpecification.PlainText entrySpec, string fullEntryKey)
    {
        return [new FlatKnowledgeBaseEntrySpecification(fullEntryKey)];
    }

    public KnowledgeBaseEntry Decode(
        EntrySpecification.PlainText entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        return new KnowledgeBaseEntry.PlainText(resolvedFlatEntries.GetRawValueOrEmpty(fullEntryKey));
    }
}