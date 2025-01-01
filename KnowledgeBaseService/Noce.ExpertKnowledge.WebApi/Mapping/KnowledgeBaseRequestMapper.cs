using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
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

    private static Dictionary<string, EntrySpec> MapEntrySpecifications(Dictionary<string, KnowledgeBaseEntrySpec> sourceSpecs)
    {
        return sourceSpecs
            .Select(kv => (kv.Key, MappedSpec: MapEntrySpecification(kv.Value, kv.Key)))
            .ToDictionary(kv => kv.Key, kv => kv.MappedSpec);
    }

    private static EntrySpec MapEntrySpecification(KnowledgeBaseEntrySpec sourceSpec, string entrySpecKey)
    {
        if (sourceSpec is { EntryType: EntryType.Compound, SubEntries.Count: > 0 })
        {
            return new EntrySpec.CompoundEntry(sourceSpec.EntryKey, entrySpecKey, MapEntrySpecifications(sourceSpec.SubEntries));
        }
        
        return sourceSpec.EntryType switch
        {
            EntryType.PlainText => new EntrySpec.PlainText(sourceSpec.EntryKey, entrySpecKey),
            EntryType.Tooltip => new EntrySpec.Tooltip(sourceSpec.EntryKey, entrySpecKey),
            EntryType.Markdown => new EntrySpec.Markdown(sourceSpec.EntryKey, entrySpecKey),
            _ => new EntrySpec.Unsupported(sourceSpec.EntryKey, entrySpecKey),
        };
    }
}