using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.WebApi.Contracts;

namespace Noce.ExpertKnowledge.WebApi.Mapping;

public class KnowledgeBaseResponseMapper : IKnowledgeBaseResponseMapper
{
    public KnowledgeBaseResponse MapToKnowledgeBaseResponse(KnowledgeBaseQueryResult queryResult)
    {
        return new KnowledgeBaseResponse
        {
            Entries = MapKnowledgeBaseEntries(queryResult.Entries)
        };
    }

    private static object MapKnowledgeBaseEntry(KnowledgeBaseEntry sourceEntry)
    {
        return sourceEntry switch
        {
            KnowledgeBaseEntry.PlainText plainText => plainText.Text,
            KnowledgeBaseEntry.Tooltip tooltip => new Dictionary<string, string>
            {
                { "title", tooltip.Title },
                { "content", tooltip.Content },
            },
            KnowledgeBaseEntry.Markdown markdown => new Dictionary<string, string>
            {
                { "markdownContent", markdown.MarkdownContent },
            },
            KnowledgeBaseEntry.CompoundEntry compoundEntry => MapKnowledgeBaseEntries(compoundEntry.Entries),
            KnowledgeBaseEntry.MissingEntryPlaceholder _ => string.Empty,
            _ => throw new ArgumentOutOfRangeException(nameof(sourceEntry))
        };
    }

    private static Dictionary<string, object> MapKnowledgeBaseEntries(
        Dictionary<string, KnowledgeBaseEntry> sourceEntries)
    {
        return sourceEntries
            .Select(kv => (kv.Key, MappedEntry: MapKnowledgeBaseEntry(kv.Value)))
            .ToDictionary(kv => kv.Key, kv => kv.MappedEntry);
    }
}