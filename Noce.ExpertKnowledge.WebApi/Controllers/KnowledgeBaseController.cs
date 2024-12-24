using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.WebApi.Contracts;

namespace Noce.ExpertKnowledge.WebApi.Controllers;

[ApiController]
[Route("{controller}/{action}")]
public class KnowledgeBaseController : ControllerBase
{
    private readonly IKnowledgeBaseQueryProcessor _knowledgeBaseQueryProcessor;
    private readonly IMapper _mapper;

    public KnowledgeBaseController(
        IKnowledgeBaseQueryProcessor knowledgeBaseQueryProcessor,
        IMapper mapper)
    {
        _knowledgeBaseQueryProcessor = knowledgeBaseQueryProcessor;
        _mapper = mapper;
    }

    [HttpPost("knowledge-entries")]
    public async Task<KnowledgeBaseResponse> QueryKnowledgeBase(KnowledgeBaseRequest request, CancellationToken cancellationToken)
    {
        var knowledgeBaseQuery = _mapper.Map<KnowledgeBaseQuery>(request);
        var result = await _knowledgeBaseQueryProcessor.QueryKnowledgeBase(knowledgeBaseQuery, cancellationToken);
        return _mapper.Map<KnowledgeBaseResponse>(result);
    }
}