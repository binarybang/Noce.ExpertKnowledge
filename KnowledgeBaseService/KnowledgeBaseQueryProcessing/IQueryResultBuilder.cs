﻿using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.Query;
using Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions.QueryResult;

namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing;

public interface IQueryResultBuilder
{
    KnowledgeBaseQueryResult BuildQueryResult(
        KnowledgeBaseQuery query,
        Dictionary<string, FlatKnowledgeBaseEntry> resolvedFlatEntries);
}