using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Infrastructure.DummyResolver;

public class DummyKnowledgeBaseEntryResolver : IFlatKnowledgeBaseEntryResolver
{
    public Task<Dictionary<string, FlatKnowledgeBaseEntry>> ResolveEntries(
        List<FlatKnowledgeBaseEntrySpecification> entrySpecs,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(entrySpecs
            .Select(es => es.EntryKey.Contains("missing", StringComparison.InvariantCultureIgnoreCase)
                ? null
                : new FlatKnowledgeBaseEntry(es.EntryKey, $"Resolved {es.EntryKey}"))
            .Where(e => e is not null)
            .ToDictionary(es => es!.EntryKey, es => es!));
    }
}