using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal static class EntryKeyUtils
{
    private const string KeySectionSeparator = ".";
    
    internal static string BuildFullEntryKey(string entryPrefix, EntrySpec entrySpec)
    {
        return CombineEntryKeySegments(entryPrefix, entrySpec.EntryKey);
    }
    
    internal static string CombineEntryKeySegments(params string[] segments)
    {
        return string.Join(KeySectionSeparator, segments);
    }
}