using System.Text;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal static class EntryUtils
{
    private const string KeySectionSeparator = ".";
    
    internal static string BuildFullEntryKey(string entryPrefix, string? entryKey, string entryDefaultKey)
    {
        var localEntryKey = string.IsNullOrWhiteSpace(entryKey) ? entryDefaultKey : entryKey;
        return CombineEntryKeySegments(entryPrefix, localEntryKey);
    }
    
    internal static string CombineEntryKeySegments(params string[] segments)
    {
        return string.Join(KeySectionSeparator, segments);
    }
}