using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public interface IEntrySpecificationProcessor<TEntrySpec> where TEntrySpec : EntrySpecification
{
    public List<FlatKnowledgeBaseEntrySpecification> Encode(
        TEntrySpec entrySpec,
        string fullEntryKey);
    
    public KnowledgeBaseEntry Decode(
        TEntrySpec entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries);
}

public interface IRecursiveEntrySpecificationProcessor<TEntrySpec> where TEntrySpec : EntrySpecification
{
    public List<FlatKnowledgeBaseEntrySpecification> EncodeRecursive(
        TEntrySpec entrySpec,
        string fullEntryKey,
        IEntrySpecificationsEncoder encoder);
    
    public KnowledgeBaseEntry DecodeRecursive(
        TEntrySpec entrySpec,
        string fullEntryKey,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries,
        IEntrySpecificationsDecoder decoder);
}