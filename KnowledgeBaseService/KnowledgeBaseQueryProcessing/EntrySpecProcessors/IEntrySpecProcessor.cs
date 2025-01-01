using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

public interface IEntrySpecProcessor<TEntrySpec> where TEntrySpec : EntrySpec
{
    public List<FlatKnowledgeBaseEntrySpec> Encode(
        TEntrySpec entrySpec,
        string fullEntryKey);
    
    public KnowledgeBaseEntry Decode(
        TEntrySpec entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries);
}

public interface IRecursiveEntrySpecProcessor<TEntrySpec> where TEntrySpec : EntrySpec
{
    public List<FlatKnowledgeBaseEntrySpec> EncodeRecursive(
        TEntrySpec entrySpec,
        string fullEntryKey,
        IEntrySpecsEncoder encoder);
    
    public KnowledgeBaseEntry DecodeRecursive(
        TEntrySpec entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries,
        IEntrySpecDecoder decoder);
}