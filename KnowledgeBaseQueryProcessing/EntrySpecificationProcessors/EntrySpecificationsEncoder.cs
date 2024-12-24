using Microsoft.Extensions.Logging;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

internal class EntrySpecificationsEncoder : IEntrySpecificationsEncoder
{
    private readonly IEntrySpecificationProcessor<EntrySpecification.PlainText> _plainTextEncoder;
    private readonly IEntrySpecificationProcessor<EntrySpecification.Tooltip> _tooltipEncoder;
    private readonly IEntrySpecificationProcessor<EntrySpecification.Markdown> _markdownEncoder;
    private readonly IRecursiveEntrySpecificationProcessor<EntrySpecification.CompoundEntry> _compoundEncoder;
    private readonly ILogger<EntrySpecificationsEncoder> _logger;


    public EntrySpecificationsEncoder(
        IEntrySpecificationProcessor<EntrySpecification.PlainText> plainTextEncoder,
        IEntrySpecificationProcessor<EntrySpecification.Tooltip> tooltipEncoder,
        IEntrySpecificationProcessor<EntrySpecification.Markdown> markdownEncoder,
        IRecursiveEntrySpecificationProcessor<EntrySpecification.CompoundEntry> compoundEncoder,
        ILogger<EntrySpecificationsEncoder> logger)
    {
        _plainTextEncoder = plainTextEncoder;
        _tooltipEncoder = tooltipEncoder;
        _markdownEncoder = markdownEncoder;
        _compoundEncoder = compoundEncoder;
        _logger = logger;
    }

    public IEnumerable<FlatKnowledgeBaseEntrySpecification> EncodeEntrySpecifications(
        string elementKeyPrefix,
        Dictionary<string, EntrySpecification> entrySpecs)
    {
        return entrySpecs
            .SelectMany(kv => EncodeEntrySpecification(elementKeyPrefix, kv.Key, kv.Value));
    }

    private IEnumerable<FlatKnowledgeBaseEntrySpecification> EncodeEntrySpecification(
        string elementKeyPrefix,
        string entryDefaultKey,
        EntrySpecification entrySpec)
    {
        var fullEntryKey = EntryUtils.BuildFullEntryKey(elementKeyPrefix, entrySpec.ElementKey, entryDefaultKey);
        
        var flatEntries = entrySpec switch
        {
            EntrySpecification.PlainText ptSpec => _plainTextEncoder.Encode(ptSpec, fullEntryKey),
            EntrySpecification.Tooltip tooltipSpec => _tooltipEncoder.Encode(tooltipSpec, fullEntryKey),
            EntrySpecification.Markdown markdownSpec => _markdownEncoder.Encode(markdownSpec, fullEntryKey), 
            EntrySpecification.CompoundEntry compoundSpec => _compoundEncoder.EncodeRecursive(compoundSpec, fullEntryKey, this),
            _ => []
        };

        if (flatEntries.Count == 0)
        {
            _logger.LogWarning("No encoded entries were created for spec {EntrySpecification}", entrySpec);
        }

        return flatEntries;
    }
}