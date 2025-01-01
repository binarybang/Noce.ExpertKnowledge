using Microsoft.Extensions.DependencyInjection;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecProcessors;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKnowledgeBaseQueryProcessing(this IServiceCollection services)
    {
        return services
            .AddTransient<IKnowledgeBaseQueryProcessor, KnowledgeBaseQueryProcessor>()
            .AddTransient<IQueryResultBuilder, QueryResultBuilder>()
            .AddTransient<IEntrySpecsEncoder, EntrySpecsEncoder>()
            .AddTransient<IEntrySpecDecoder, EntrySpecDecoder>()
            .AddEntrySpecificationProcessors();
    }

    private static IServiceCollection AddEntrySpecificationProcessors(this IServiceCollection services)
    {
        return services
            .AddTransient<IEntrySpecProcessor<EntrySpec.PlainText>,
                PlainTextEntrySpecProcessor>()
            .AddTransient<IEntrySpecProcessor<EntrySpec.Tooltip>,
                TooltipEntrySpecProcessor>()
            .AddTransient<IEntrySpecProcessor<EntrySpec.Markdown>,
                MarkdownEntrySpecProcessor>()
            .AddTransient<IRecursiveEntrySpecProcessor<EntrySpec.CompoundEntry>,
                CompoundEntrySpecProcessor>()
            .AddTransient<IEntrySpecProcessor<EntrySpec.TextWithPlaceholders>,
                TextWithPlaceholdersSpecProcessor>();
    }
}