using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

internal static class FlatEntryExtensions
{
    internal static string GetRawValueOrEmpty(
        this Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries,
        string fullEntryKey)
    {
        return resolvedFlatEntries.TryGetValue(fullEntryKey, out var entry) 
            ? entry.RawValue 
            : string.Empty;
    }
}