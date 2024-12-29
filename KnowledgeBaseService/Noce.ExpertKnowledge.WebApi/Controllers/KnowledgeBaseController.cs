using Microsoft.AspNetCore.Mvc;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.WebApi.Contracts;
using Noce.ExpertKnowledge.WebApi.Mapping;

namespace Noce.ExpertKnowledge.WebApi.Controllers;

[ApiController]
[Route("knowledge-base")]
public class KnowledgeBaseController : ControllerBase
{
    private readonly IKnowledgeBaseQueryProcessor _knowledgeBaseQueryProcessor;
    private readonly IKnowledgeBaseRequestMapper _requestMapper;
    private readonly IKnowledgeBaseResponseMapper _responseMapper;

    public KnowledgeBaseController(
        IKnowledgeBaseQueryProcessor knowledgeBaseQueryProcessor,
        IKnowledgeBaseRequestMapper requestMapper, 
        IKnowledgeBaseResponseMapper responseMapper)
    {
        _knowledgeBaseQueryProcessor = knowledgeBaseQueryProcessor;
        _requestMapper = requestMapper;
        _responseMapper = responseMapper;
    }

    [HttpPost("query")]
    public async Task<KnowledgeBaseResponse> QueryKnowledgeBase(KnowledgeBaseRequest request, CancellationToken cancellationToken)
    {
        var knowledgeBaseQuery = _requestMapper.MapToKnowledgeBaseQuery(request);
        var queryResult = await _knowledgeBaseQueryProcessor.QueryKnowledgeBase(knowledgeBaseQuery, cancellationToken);
        return _responseMapper.MapToKnowledgeBaseResponse(queryResult);
    }
}