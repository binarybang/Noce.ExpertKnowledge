using System.Text;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal static class EntryUtils
{
    private const string KeySectionSeparator = ".";
    
    internal static string BuildFullEntryKey(string entryPrefix, string entryElementKey, string entryDefaultKey)
    {
        var localEntryKey = string.IsNullOrWhiteSpace(entryElementKey) ? entryDefaultKey : entryElementKey;
        return CombineEntryKeySegments(entryPrefix, localEntryKey);
    }
    
    internal static string CombineEntryKeySegments(params string[] segments)
    {
        return string.Join(KeySectionSeparator, segments);
    }
}