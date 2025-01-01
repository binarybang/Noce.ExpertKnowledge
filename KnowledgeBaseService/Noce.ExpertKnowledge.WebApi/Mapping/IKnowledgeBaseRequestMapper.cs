using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.WebApi.Contracts;
using Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest;

namespace Noce.ExpertKnowledge.WebApi.Mapping;

public interface IKnowledgeBaseRequestMapper
{
    KnowledgeBaseQuery MapToKnowledgeBaseQuery(KnowledgeBaseRequest request);
}