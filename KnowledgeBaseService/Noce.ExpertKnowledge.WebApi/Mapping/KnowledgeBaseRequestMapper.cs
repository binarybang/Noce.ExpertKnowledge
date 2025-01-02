using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest;

namespace Noce.ExpertKnowledge.WebApi.Mapping;

public class KnowledgeBaseRequestMapper : IKnowledgeBaseRequestMapper
{
    public KnowledgeBaseQuery MapToKnowledgeBaseQuery(KnowledgeBaseRequest request)
    {
        return new KnowledgeBaseQuery
        {
            EntryKeyPrefix = request.EntryKeyPrefix ?? string.Empty,
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
        var entryKey = sourceSpec.EntryKey ?? entrySpecKey;
        
        if (sourceSpec is KnowledgeBaseEntrySpec.CompoundEntry compoundEntrySpec)
        {
            return new EntrySpec.CompoundEntry(entryKey, MapEntrySpecifications(compoundEntrySpec.SubEntries));
        }
        
        return sourceSpec switch
        {
            KnowledgeBaseEntrySpec.PlainText => new EntrySpec.PlainText(entryKey),
            KnowledgeBaseEntrySpec.TextWithPlaceholders twp => new EntrySpec.TextWithPlaceholders(entryKey, twp.Replacements),
            KnowledgeBaseEntrySpec.Tooltip => new EntrySpec.Tooltip(entryKey),
            KnowledgeBaseEntrySpec.Markdown => new EntrySpec.Markdown(entryKey),
            _ => new EntrySpec.Unsupported(entryKey),
        };
    }
}