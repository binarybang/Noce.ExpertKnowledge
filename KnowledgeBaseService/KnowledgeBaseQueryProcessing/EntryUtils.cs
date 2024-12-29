using System.Text;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

internal static class EntryUtils
{
    private const string KeySectionSeparator = ".";
    
    internal static string BuildFullEntryKey(string entryPrefix, EntrySpecification entrySpec)
    {
        return CombineEntryKeySegments(entryPrefix, entrySpec.EntryKeyForResolution);
    }
    
    internal static string CombineEntryKeySegments(params string[] segments)
    {
        return string.Join(KeySectionSeparator, segments);
    }
}