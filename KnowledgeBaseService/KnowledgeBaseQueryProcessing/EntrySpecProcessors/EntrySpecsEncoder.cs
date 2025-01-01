using Microsoft.Extensions.Logging;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

internal class EntrySpecsEncoder : IEntrySpecsEncoder
{
    private readonly IEntrySpecProcessor<EntrySpec.PlainText> _plainTextEncoder;
    private readonly IEntrySpecProcessor<EntrySpec.TextWithPlaceholders> _textWithPlaceholdersEncoder;
    private readonly IEntrySpecProcessor<EntrySpec.Tooltip> _tooltipEncoder;
    private readonly IEntrySpecProcessor<EntrySpec.Markdown> _markdownEncoder;
    private readonly IRecursiveEntrySpecProcessor<EntrySpec.CompoundEntry> _compoundEncoder;
    private readonly ILogger<EntrySpecsEncoder> _logger;


    public EntrySpecsEncoder(
        IEntrySpecProcessor<EntrySpec.PlainText> plainTextEncoder,
        IEntrySpecProcessor<EntrySpec.TextWithPlaceholders> textWithPlaceholdersEncoder,
        IEntrySpecProcessor<EntrySpec.Tooltip> tooltipEncoder,
        IEntrySpecProcessor<EntrySpec.Markdown> markdownEncoder,
        IRecursiveEntrySpecProcessor<EntrySpec.CompoundEntry> compoundEncoder,
        ILogger<EntrySpecsEncoder> logger)
    {
        _plainTextEncoder = plainTextEncoder;
        _textWithPlaceholdersEncoder = textWithPlaceholdersEncoder;
        _tooltipEncoder = tooltipEncoder;
        _markdownEncoder = markdownEncoder;
        _compoundEncoder = compoundEncoder;
        _logger = logger;
    }

    public IEnumerable<FlatKnowledgeBaseEntrySpec> EncodeEntrySpecs(
        string entryKeyPrefix,
        Dictionary<string, EntrySpec> entrySpecs)
    {
        return entrySpecs
            .SelectMany(kv => EncodeEntrySpec(entryKeyPrefix, kv.Value));
    }

    private IEnumerable<FlatKnowledgeBaseEntrySpec> EncodeEntrySpec(
        string entryKeyPrefix,
        EntrySpec entrySpec)
    {
        var fullEntryKey = EntryKeyUtils.BuildFullEntryKey(entryKeyPrefix, entrySpec);
        
        var flatEntries = entrySpec switch
        {
            EntrySpec.PlainText ptSpec => _plainTextEncoder.Encode(ptSpec, fullEntryKey),
            EntrySpec.TextWithPlaceholders twpSpec => _textWithPlaceholdersEncoder.Encode(twpSpec, fullEntryKey),
            EntrySpec.Tooltip tooltipSpec => _tooltipEncoder.Encode(tooltipSpec, fullEntryKey),
            EntrySpec.Markdown markdownSpec => _markdownEncoder.Encode(markdownSpec, fullEntryKey), 
            EntrySpec.CompoundEntry compoundSpec => _compoundEncoder.EncodeRecursive(compoundSpec, fullEntryKey, this),
            _ => []
        };

        if (flatEntries.Count == 0)
        {
            _logger.LogWarning("No encoded entries were created for spec {EntrySpec}", entrySpec);
        }

        return flatEntries;
    }
}