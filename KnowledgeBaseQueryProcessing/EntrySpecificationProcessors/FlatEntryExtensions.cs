using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

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