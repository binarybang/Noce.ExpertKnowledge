using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.WebApi.Contracts;

namespace Noce.ExpertKnowledge.WebApi.Mapping;

public interface IKnowledgeBaseResponseMapper
{
    KnowledgeBaseResponse MapToKnowledgeBaseResponse(KnowledgeBaseQueryResult queryResult);
}