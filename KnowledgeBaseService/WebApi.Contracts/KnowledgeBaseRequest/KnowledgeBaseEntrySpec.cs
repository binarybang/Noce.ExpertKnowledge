using System.Text.Json.Serialization;

namespace Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "entryType", IgnoreUnrecognizedTypeDiscriminators = true)]
[JsonDerivedType(typeof(PlainText), (int)EntryType.PlainText)]
[JsonDerivedType(typeof(TextWithPlaceholders), (int)EntryType.TextWithPlaceholders)]
[JsonDerivedType(typeof(Tooltip), (int)EntryType.Tooltip)]
[JsonDerivedType(typeof(Markdown), (int)EntryType.Markdown)]
[JsonDerivedType(typeof(CompoundEntry), (int)EntryType.Compound)]
public record KnowledgeBaseEntrySpec
{
    public string? EntryKey { get; init; }
    
    public sealed record PlainText(): KnowledgeBaseEntrySpec;

    public sealed record TextWithPlaceholders : KnowledgeBaseEntrySpec
    {
        public required Dictionary<string, string> Replacements { get; init; }
    }
    
    public sealed record Tooltip: KnowledgeBaseEntrySpec;
    
    public sealed record Markdown(): KnowledgeBaseEntrySpec;

    public sealed record CompoundEntry: KnowledgeBaseEntrySpec
    {
        public required Dictionary<string, KnowledgeBaseEntrySpec> SubEntries { get; init; } 
    }
}