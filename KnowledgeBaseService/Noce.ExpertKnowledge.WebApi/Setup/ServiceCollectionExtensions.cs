using Infrastructure.DummyResolver;
using Microsoft.OpenApi.Models;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;
using Noce.ExpertKnowledge.WebApi.Mapping;

namespace Noce.ExpertKnowledge.WebApi.Setup;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddKnowledgeBaseQueryProcessing();
    }

    internal static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDummyFlatEntryResolver()
            .AddKnowledgeBaseContractMapping();
    }

    internal static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var serverUrl = configuration.GetValue<string>("SwaggerUi:ServerUrl");
        if (!string.IsNullOrWhiteSpace(serverUrl))
        {
            return services
                .AddSwaggerGen(o => o.AddServer(new OpenApiServer {Url = serverUrl}));
        }
        
        return services.AddSwaggerGen();
    }
}