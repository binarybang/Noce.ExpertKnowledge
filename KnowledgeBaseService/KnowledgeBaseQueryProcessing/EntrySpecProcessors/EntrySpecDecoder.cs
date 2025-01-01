using Microsoft.Extensions.Logging;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

internal class EntrySpecDecoder : IEntrySpecDecoder
{
    private readonly IEntrySpecProcessor<EntrySpec.PlainText> _plainTextDecoder;
    private readonly IEntrySpecProcessor<EntrySpec.Tooltip> _tooltipDecoder;
    private readonly IEntrySpecProcessor<EntrySpec.Markdown> _markdownDecoder;
    private readonly IRecursiveEntrySpecProcessor<EntrySpec.CompoundEntry> _compoundDecoder;
    private readonly ILogger<EntrySpecDecoder> _logger;


    public EntrySpecDecoder(
        IEntrySpecProcessor<EntrySpec.PlainText> plainTextDecoder,
        IEntrySpecProcessor<EntrySpec.Tooltip> tooltipDecoder,
        IEntrySpecProcessor<EntrySpec.Markdown> markdownDecoder,
        IRecursiveEntrySpecProcessor<EntrySpec.CompoundEntry> compoundDecoder,
        ILogger<EntrySpecDecoder> logger)
    {
        _plainTextDecoder = plainTextDecoder;
        _tooltipDecoder = tooltipDecoder;
        _markdownDecoder = markdownDecoder;
        _compoundDecoder = compoundDecoder;
        _logger = logger;
    }

    public Dictionary<string, KnowledgeBaseEntry> DecodeEntrySpecs(
        string entryKeyPrefix,
        Dictionary<string, EntrySpec> entrySpecs,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var result = new Dictionary<string, KnowledgeBaseEntry>();
        foreach (var (key, entrySpec) in entrySpecs)
        {
            var fullEntryKey = EntryUtils.BuildFullEntryKey(entryKeyPrefix, entrySpec);
            var resolvedEntry = entrySpec switch
            {
                EntrySpec.PlainText ptSpec => _plainTextDecoder.Decode(ptSpec, fullEntryKey, resolvedFlatEntries),
                EntrySpec.Tooltip tooltipSpec => _tooltipDecoder.Decode(tooltipSpec, fullEntryKey, resolvedFlatEntries),
                EntrySpec.Markdown markdownSpec => _markdownDecoder.Decode(markdownSpec, fullEntryKey, resolvedFlatEntries), 
                EntrySpec.CompoundEntry compoundSpec => _compoundDecoder.DecodeRecursive(compoundSpec, fullEntryKey, resolvedFlatEntries, this),
                _ => new KnowledgeBaseEntry.MissingEntryPlaceholder()
            };

            if (resolvedEntry is KnowledgeBaseEntry.MissingEntryPlaceholder)
            {
                _logger.LogWarning("Missing entry decoder for spec {EntrySpec}", entrySpec);
            }
            result[key] = resolvedEntry;
        }
        
        return result;
    }
}