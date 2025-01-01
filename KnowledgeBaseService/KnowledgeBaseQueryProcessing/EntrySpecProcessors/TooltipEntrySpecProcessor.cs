using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public class TooltipEntrySpecProcessor : IEntrySpecProcessor<EntrySpec.Tooltip>
{
    private const string TooltipTitleKey = "title";
    private const string TooltipContentKey = "content";
    
    public List<FlatKnowledgeBaseEntrySpec> Encode(EntrySpec.Tooltip entrySpec, string fullEntryKey)
    {
        var titleKey = EntryUtils.CombineEntryKeySegments(fullEntryKey, TooltipTitleKey);
        var contentKey = EntryUtils.CombineEntryKeySegments(fullEntryKey, TooltipContentKey);
        
        return [
            new FlatKnowledgeBaseEntrySpec(titleKey),
            new FlatKnowledgeBaseEntrySpec(contentKey)
        ];
    }

    public KnowledgeBaseEntry Decode(
        EntrySpec.Tooltip entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var titleKey = EntryUtils.CombineEntryKeySegments(fullEntryKey, TooltipTitleKey);
        var contentKey = EntryUtils.CombineEntryKeySegments(fullEntryKey, TooltipContentKey);

        return new KnowledgeBaseEntry.Tooltip(
            resolvedFlatEntries.GetRawValueOrEmpty(titleKey),
            resolvedFlatEntries.GetRawValueOrEmpty(contentKey)
        );
    }
}