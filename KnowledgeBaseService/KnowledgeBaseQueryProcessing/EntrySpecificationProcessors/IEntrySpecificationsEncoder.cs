using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public interface IEntrySpecificationsEncoder
{
    IEnumerable<FlatKnowledgeBaseEntrySpecification> EncodeEntrySpecifications(
        string entryKeyPrefix, Dictionary<string, EntrySpecification> entrySpecs);
}