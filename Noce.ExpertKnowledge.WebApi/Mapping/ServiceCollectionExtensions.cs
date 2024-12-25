namespace Noce.ExpertKnowledge.WebApi.Mapping;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKnowledgeBaseContractMapping(this IServiceCollection services)
    {
        return services
            .AddTransient<IKnowledgeBaseRequestMapper, KnowledgeBaseRequestMapper>()
            .AddTransient<IKnowledgeBaseResponseMapper, KnowledgeBaseResponseMapper>();
    }
}