using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public class TooltipEntrySpecificationProcessor : IEntrySpecificationProcessor<EntrySpecification.Tooltip>
{
    private const string TooltipTitleKey = "title";
    private const string TooltipContentKey = "content";
    
    public List<FlatKnowledgeBaseEntrySpecification> Encode(EntrySpecification.Tooltip entrySpec, string fullEntryKey)
    {
        var titleKey = EntryUtils.CombineEntryKeySegments(fullEntryKey, TooltipTitleKey);
        var contentKey = EntryUtils.CombineEntryKeySegments(fullEntryKey, TooltipContentKey);
        
        return [
            new FlatKnowledgeBaseEntrySpecification(titleKey),
            new FlatKnowledgeBaseEntrySpecification(contentKey)
        ];
    }

    public KnowledgeBaseEntry Decode(
        EntrySpecification.Tooltip entrySpec,
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