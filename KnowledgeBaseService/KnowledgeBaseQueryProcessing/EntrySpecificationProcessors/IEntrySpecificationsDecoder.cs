using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public interface IEntrySpecificationsDecoder
{
    Dictionary<string, KnowledgeBaseEntry> DecodeEntrySpecifications(
        string entryKeyPrefix,
        Dictionary<string, EntrySpecification> entrySpecs,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries);
}