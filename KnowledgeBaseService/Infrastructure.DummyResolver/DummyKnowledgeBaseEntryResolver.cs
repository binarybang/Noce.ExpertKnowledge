using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Infrastructure.DummyResolver;

public class DummyKnowledgeBaseEntryResolver : IFlatKnowledgeBaseEntryResolver
{
    public Task<Dictionary<string, FlatKnowledgeBaseEntry>> ResolveEntries(
        List<FlatKnowledgeBaseEntrySpec> entrySpecs,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(entrySpecs
            .Select(ResolveEntrySpec)
            .Where(e => e is not null)
            .ToDictionary(es => es!.EntryKey, es => es!));
    }

    private static FlatKnowledgeBaseEntry? ResolveEntrySpec(FlatKnowledgeBaseEntrySpec entrySpec)
    {
        return entrySpec.EntryKey switch
        {
            { } missingKey when missingKey.Contains("missing", StringComparison.InvariantCultureIgnoreCase) => null,
            { } placeholderKey when placeholderKey.Contains("placeholder", StringComparison.InvariantCultureIgnoreCase)
                =>
                new FlatKnowledgeBaseEntry(placeholderKey,
                    $"Resolved with placeholder [[placeholder]] for key {placeholderKey}"),
            { } key => new FlatKnowledgeBaseEntry(key, $"Resolved for key {key}")
        };
    }
}