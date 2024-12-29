using Microsoft.Extensions.DependencyInjection;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.EntrySpecificationProcessors;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKnowledgeBaseQueryProcessing(this IServiceCollection services)
    {
        return services
            .AddTransient<IKnowledgeBaseQueryProcessor, KnowledgeBaseQueryProcessor>()
            .AddTransient<IQueryResultBuilder, QueryResultBuilder>()
            .AddTransient<IEntrySpecificationsEncoder, EntrySpecificationsEncoder>()
            .AddTransient<IEntrySpecificationsDecoder, EntrySpecificationsDecoder>()
            .AddEntrySpecificationProcessors();
    }

    private static IServiceCollection AddEntrySpecificationProcessors(this IServiceCollection services)
    {
        return services
            .AddTransient<IEntrySpecificationProcessor<EntrySpecification.PlainText>,
                PlainTextEntrySpecificationProcessor>()
            .AddTransient<IEntrySpecificationProcessor<EntrySpecification.Tooltip>,
                TooltipEntrySpecificationProcessor>()
            .AddTransient<IEntrySpecificationProcessor<EntrySpecification.Markdown>,
                MarkdownEntrySpecificationProcessor>()
            .AddTransient<IRecursiveEntrySpecificationProcessor<EntrySpecification.CompoundEntry>,
                CompoundEntrySpecificationProcessor>();
    }
}