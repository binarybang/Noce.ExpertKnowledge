namespace Noce.ExpertKnowledge.WebApi.Contracts.KnowledgeBaseRequest2;

public abstract record KnowledgeBaseEntrySpec2
{
    public string? EntryKey { get; init; }
    
    public sealed record Unsupported : KnowledgeBaseEntrySpec2;
    public sealed record PlainText(): KnowledgeBaseEntrySpec2;

    public sealed record TextWithPlaceholders : KnowledgeBaseEntrySpec2
    {
        public required Dictionary<string, string> Replacements { get; init; }
    }
    
    public sealed record Tooltip: KnowledgeBaseEntrySpec2;
    public sealed record Markdown(): KnowledgeBaseEntrySpec2;

    public sealed record CompoundEntry: KnowledgeBaseEntrySpec2
    {
        public required Dictionary<string, KnowledgeBaseEntrySpec2> SubEntries { get; init; } 
    }
    
}