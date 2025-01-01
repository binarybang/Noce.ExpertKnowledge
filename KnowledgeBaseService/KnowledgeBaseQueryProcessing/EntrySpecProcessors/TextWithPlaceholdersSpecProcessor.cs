using System.Text;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public class TextWithPlaceholdersSpecProcessor: IEntrySpecProcessor<EntrySpec.TextWithPlaceholders>
{
    public List<FlatKnowledgeBaseEntrySpec> Encode(
        EntrySpec.TextWithPlaceholders entrySpec,
        string fullEntryKey)
    {
        return [new FlatKnowledgeBaseEntrySpec(fullEntryKey)];
    }

    public KnowledgeBaseEntry Decode(EntrySpec.TextWithPlaceholders entrySpec, string fullEntryKey, Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries)
    {
        var rawValue = resolvedFlatEntries.GetRawValueOrEmpty(fullEntryKey);
        if (string.IsNullOrEmpty(rawValue))
        {
            return new KnowledgeBaseEntry.TextWithPlaceholders(rawValue);
        }
        
        var sb = new StringBuilder(rawValue);
        foreach (var (key, value) in entrySpec.Replacements)
        {
            sb.Replace(key, value);
        }

        var valueAfterReplacements = sb.ToString();

        return new KnowledgeBaseEntry.TextWithPlaceholders(valueAfterReplacements);
    }
}