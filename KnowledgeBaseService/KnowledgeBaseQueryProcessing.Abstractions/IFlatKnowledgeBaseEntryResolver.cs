namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public interface IFlatKnowledgeBaseEntryResolver
{
    public Task<Dictionary<string, FlatKnowledgeBaseEntry>> ResolveEntries(
        List<FlatKnowledgeBaseEntrySpecification> entrySpecs,
        CancellationToken cancellationToken);
}