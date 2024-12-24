using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public class CompoundEntrySpecificationProcessor : IRecursiveEntrySpecificationProcessor<EntrySpecification.CompoundEntry>
{
    public List<FlatKnowledgeBaseEntrySpecification> EncodeRecursive(
        EntrySpecification.CompoundEntry entrySpec,
        string fullEntryKey,
        IEntrySpecificationsEncoder encoder)
    {
        return encoder
            .EncodeEntrySpecifications(fullEntryKey, entrySpec.SubEntries)
            .ToList();
    }

    public KnowledgeBaseEntry DecodeRecursive(
        EntrySpecification.CompoundEntry entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries,
        IEntrySpecificationsDecoder decoder)
    {
        var subEntries = decoder.DecodeEntrySpecifications(fullEntryKey, entrySpec.SubEntries, resolvedFlatEntries);
        return new KnowledgeBaseEntry.CompoundEntry(subEntries);

    }
}