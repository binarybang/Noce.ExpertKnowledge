﻿using Infrastructure.DummyResolver;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

namespace Noce.ExpertKnowledge.WebApi.Setup;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddKnowledgeBaseQueryProcessing();
    }

    internal static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDummyFlatEntryResolver();
    }
}