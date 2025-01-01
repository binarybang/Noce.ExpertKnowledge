using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public class CompoundEntrySpecProcessor : IRecursiveEntrySpecProcessor<EntrySpec.CompoundEntry>
{
    public List<FlatKnowledgeBaseEntrySpec> EncodeRecursive(
        EntrySpec.CompoundEntry entrySpec,
        string fullEntryKey,
        IEntrySpecsEncoder encoder)
    {
        return encoder
            .EncodeEntrySpecs(fullEntryKey, entrySpec.SubEntries)
            .ToList();
    }

    public KnowledgeBaseEntry DecodeRecursive(
        EntrySpec.CompoundEntry entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries,
        IEntrySpecDecoder decoder)
    {
        var subEntries = decoder.DecodeEntrySpecs(fullEntryKey, entrySpec.SubEntries, resolvedFlatEntries);
        return new KnowledgeBaseEntry.CompoundEntry(subEntries);

    }
}