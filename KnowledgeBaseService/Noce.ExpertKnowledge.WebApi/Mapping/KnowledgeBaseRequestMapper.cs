using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.WebApi.Contracts;

namespace Noce.ExpertKnowledge.WebApi.Mapping;

public class KnowledgeBaseRequestMapper : IKnowledgeBaseRequestMapper
{
    public KnowledgeBaseQuery MapToKnowledgeBaseQuery(KnowledgeBaseRequest request)
    {
        return new KnowledgeBaseQuery
        {
            ElementPrefix = request.EntryKeyPrefix,
            Entries = MapEntrySpecifications(request.Entries)
        };
    }

    private static Dictionary<string, EntrySpecification> MapEntrySpecifications(Dictionary<string, KnowledgeBaseEntrySpecification> sourceSpecs)
    {
        return sourceSpecs
            .Select(kv => (kv.Key, MappedSpec: MapEntrySpecification(kv.Value)))
            .ToDictionary(kv => kv.Key, kv => kv.MappedSpec);
    }

    private static EntrySpecification MapEntrySpecification(KnowledgeBaseEntrySpecification sourceSpec)
    {
        if (sourceSpec is { EntryType: EntryType.Compound, SubEntries.Count: > 0 })
        {
            return new EntrySpecification.CompoundEntry(sourceSpec.EntryKey, MapEntrySpecifications(sourceSpec.SubEntries));
        }
        
        return sourceSpec.EntryType switch
        {
            EntryType.PlainText => new EntrySpecification.PlainText(sourceSpec.EntryKey),
            EntryType.Tooltip => new EntrySpecification.Tooltip(sourceSpec.EntryKey),
            EntryType.Markdown => new EntrySpecification.Markdown(sourceSpec.EntryKey),
            _ => throw new InvalidOperationException($"Cannot map entry type {sourceSpec.EntryType} to entry specification")
        };
    }
}