using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Infrastructure.DummyResolver;

public class DummyKnowledgeBaseEntryResolver : IFlatKnowledgeBaseEntryResolver
{
    public Task<Dictionary<string, FlatKnowledgeBaseEntry>> ResolveEntries(
        List<FlatKnowledgeBaseEntrySpecification> entrySpecs,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(entrySpecs
            .Select(es => new FlatKnowledgeBaseEntry(es.EntryKey, $"Resolved {es.EntryKey}"))
            .ToDictionary(es => es.EntryKey, es => es));
    }
}