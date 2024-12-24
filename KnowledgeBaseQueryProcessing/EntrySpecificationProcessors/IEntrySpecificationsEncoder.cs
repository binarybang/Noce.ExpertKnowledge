using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

public interface IEntrySpecificationsEncoder
{
    IEnumerable<FlatKnowledgeBaseEntrySpecification> EncodeEntrySpecifications(
        string elementKeyPrefix, Dictionary<string, EntrySpecification> entrySpecs);
}