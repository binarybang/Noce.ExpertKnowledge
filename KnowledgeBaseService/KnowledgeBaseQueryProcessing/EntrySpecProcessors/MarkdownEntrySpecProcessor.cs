using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public class MarkdownEntrySpecProcessor : IEntrySpecProcessor<EntrySpec.Markdown>
{
    public List<FlatKnowledgeBaseEntrySpec> Encode(
        EntrySpec.Markdown entrySpec,
        string fullEntryKey)
    {
        return [new FlatKnowledgeBaseEntrySpec(fullEntryKey)];
    }

    public KnowledgeBaseEntry Decode(
        EntrySpec.Markdown entrySpec,
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