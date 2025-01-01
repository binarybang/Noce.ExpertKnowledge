using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest2;

public class KnowledgeBaseEntrySpec2Converter : JsonConverter<KnowledgeBaseEntrySpec2>
{
    public override KnowledgeBaseEntrySpec2? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var specNode = JsonNode.Parse(ref reader);
        if (specNode == null)
        {
            return null;
        }

        var entryType = specNode["entryType"]?.Deserialize<EntryType2>();

        return entryType switch
        {
            EntryType2.PlainText => CreatePlainTextSpec(specNode),
            EntryType2.TextWithPlaceholders => CreateTextWithPlaceholdersSpec(specNode),
            EntryType2.Tooltip => CreateMarkdownSpec(specNode),
            EntryType2.Markdown => CreateMarkdownSpec(specNode),
            EntryType2.Compound => CreateCompoundSpec(specNode, options),
            _ => throw new InvalidOperationException($"Entry type {specNode["entryType"]} is not supported by API")
        };
    }

    private KnowledgeBaseEntrySpec2? CreatePlainTextSpec(JsonNode specNode)
    {
        return new KnowledgeBaseEntrySpec2.PlainText
        {
            EntryKey = specNode.ReadEntryKey()
        };
    }
    
    private KnowledgeBaseEntrySpec2? CreateTextWithPlaceholdersSpec(JsonNode specNode)
    {
        var replacements = specNode["replacements"]?.Deserialize<Dictionary<string, string>>();
        return new KnowledgeBaseEntrySpec2.TextWithPlaceholders
        {
            EntryKey = specNode.ReadEntryKey(),
            Replacements = replacements ?? new Dictionary<string, string>()
        };
    }
    
    private KnowledgeBaseEntrySpec2? CreateMarkdownSpec(JsonNode specNode)
    {
        return new KnowledgeBaseEntrySpec2.Markdown
        {
            EntryKey = specNode.ReadEntryKey()
        };
    }
    
    private KnowledgeBaseEntrySpec2? CreateCompoundSpec(JsonNode specNode, JsonSerializerOptions options)
    {
        var subEntries = specNode["subEntries"]?.Deserialize<Dictionary<string, KnowledgeBaseEntrySpec2>>(options);
        return new KnowledgeBaseEntrySpec2.CompoundEntry
        {
            EntryKey = specNode.ReadEntryKey(),
            SubEntries = subEntries ?? new Dictionary<string, KnowledgeBaseEntrySpec2>()
        };
    }

    public override void Write(Utf8JsonWriter writer, KnowledgeBaseEntrySpec2 value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Knowledge base entry spec is not supposed to be serialized");
    }
}