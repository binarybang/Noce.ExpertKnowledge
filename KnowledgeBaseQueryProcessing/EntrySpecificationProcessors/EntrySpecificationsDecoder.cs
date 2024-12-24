using Microsoft.Extensions.Logging;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

internal class EntrySpecificationsDecoder : IEntrySpecificationsDecoder
{
    private readonly IEntrySpecificationProcessor<EntrySpecification.PlainText> _plainTextDecoder;
    private readonly IEntrySpecificationProcessor<EntrySpecification.Tooltip> _tooltipDecoder;
    private readonly IEntrySpecificationProcessor<EntrySpecification.Markdown> _markdownDecoder;
    private readonly IRecursiveEntrySpecificationProcessor<EntrySpecification.CompoundEntry> _compoundDecoder;
    private readonly ILogger<EntrySpecificationsDecoder> _logger;


    public EntrySpecificationsDecoder(
        IEntrySpecificationProcessor<EntrySpecification.PlainText> plainTextDecoder,
        IEntrySpecificationProcessor<EntrySpecification.Tooltip> tooltipDecoder,
        IEntrySpecificationProcessor<EntrySpecification.Markdown> markdownDecoder,
        IRecursiveEntrySpecificationProcessor<EntrySpecification.CompoundEntry> compoundDecoder,
        ILogger<EntrySpecificationsDecoder> logger)
    {
        _plainTextDecoder = plainTextDecoder;
        _tooltipDecoder = tooltipDecoder;
        _markdownDecoder = markdownDecoder;
        _compoundDecoder = compoundDecoder;
        _logger = logger;
    }

    public Dictionary<string, KnowledgeBaseEntry> DecodeEntrySpecifications(
        string elementKeyPrefix,
        Dictionary<string, EntrySpecification> entrySpecs,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var result = new Dictionary<string, KnowledgeBaseEntry>();
        foreach (var kv in entrySpecs)
        {
            var entrySpec = kv.Value;
            var fullEntryKey = EntryUtils.BuildFullEntryKey(elementKeyPrefix, entrySpec.ElementKey, kv.Key);
            var resolvedEntry = kv.Value switch
            {
                EntrySpecification.PlainText ptSpec => _plainTextDecoder.Decode(ptSpec, fullEntryKey, resolvedFlatEntries),
                EntrySpecification.Tooltip tooltipSpec => _tooltipDecoder.Decode(tooltipSpec, fullEntryKey, resolvedFlatEntries),
                EntrySpecification.Markdown markdownSpec => _markdownDecoder.Decode(markdownSpec, fullEntryKey, resolvedFlatEntries), 
                EntrySpecification.CompoundEntry compoundSpec => _compoundDecoder.DecodeRecursive(compoundSpec, fullEntryKey, resolvedFlatEntries, this),
                _ => new KnowledgeBaseEntry.MissingEntryPlaceholder()
            };

            if (resolvedEntry is KnowledgeBaseEntry.MissingEntryPlaceholder missingEntry)
            {
                _logger.LogWarning("Missing entry decoder for spec {EntrySpecification}", entrySpec);
            }
            result[kv.Key] = resolvedEntry;
        }
        
        return result;
    }
}