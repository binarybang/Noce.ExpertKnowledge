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
            .Select(kv => (kv.Key, MappedSpec: MapEntrySpecification(kv.Value, kv.Key)))
            .ToDictionary(kv => kv.Key, kv => kv.MappedSpec);
    }

    private static EntrySpecification MapEntrySpecification(KnowledgeBaseEntrySpecification sourceSpec, string entrySpecKey)
    {
        if (sourceSpec is { EntryType: EntryType.Compound, SubEntries.Count: > 0 })
        {
            return new EntrySpecification.CompoundEntry(sourceSpec.EntryKey, entrySpecKey, MapEntrySpecifications(sourceSpec.SubEntries));
        }
        
        return sourceSpec.EntryType switch
        {
            EntryType.PlainText => new EntrySpecification.PlainText(sourceSpec.EntryKey, entrySpecKey),
            EntryType.Tooltip => new EntrySpecification.Tooltip(sourceSpec.EntryKey, entrySpecKey),
            EntryType.Markdown => new EntrySpecification.Markdown(sourceSpec.EntryKey, entrySpecKey),
            _ => new EntrySpecification.Unsupported(sourceSpec.EntryKey, entrySpecKey),
        };
    }
}