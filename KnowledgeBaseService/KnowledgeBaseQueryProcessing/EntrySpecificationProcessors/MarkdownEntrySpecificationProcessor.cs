using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public class MarkdownEntrySpecificationProcessor : IEntrySpecificationProcessor<EntrySpecification.Markdown>
{
    public List<FlatKnowledgeBaseEntrySpecification> Encode(
        EntrySpecification.Markdown entrySpec,
        string fullEntryKey)
    {
        return [new FlatKnowledgeBaseEntrySpecification(fullEntryKey)];
    }

    public KnowledgeBaseEntry Decode(
        EntrySpecification.Markdown entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var markdownContent = resolvedFlatEntries.GetRawValueOrEmpty(fullEntryKey);
        return new KnowledgeBaseEntry.Markdown(
            markdownContent,
            markdownContent
        );
    }
}