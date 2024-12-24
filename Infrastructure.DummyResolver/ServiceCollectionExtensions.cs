using Microsoft.Extensions.DependencyInjection;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

namespace Infrastructure.DummyResolver;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDummyFlatEntryResolver(this IServiceCollection services)
    {
        return services
            .AddTransient<IFlatKnowledgeBaseEntryResolver, DummyKnowledgeBaseEntryResolver>();
    }
}