using System.Text.Json;
using System.Text.Json.Nodes;

namespace Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest2;

internal static class JsonNodeExtensions
{
    internal static string? ReadEntryKey(this JsonNode node)
    {
        return node["entryKey"].Deserialize<string>();
    }
}