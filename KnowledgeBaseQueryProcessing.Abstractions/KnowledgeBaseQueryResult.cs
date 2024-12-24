namespace Noce.ExpertKnowledge.KnowledgeBaseQueryProcessing.Abstractions;

public class KnowledgeBaseQueryResult
{
    public required Dictionary<string, KnowledgeBaseEntry> Entries { get; init; }
}

public abstract record KnowledgeBaseEntry
{
    public sealed record PlainText(string Text) : KnowledgeBaseEntry;
    public sealed record Tooltip(string Title, string Content) : KnowledgeBaseEntry;
    public sealed record Markdown(string MarkdownContent, string HtmlContent) : KnowledgeBaseEntry;
    public sealed record CompoundEntry(Dictionary<string, KnowledgeBaseEntry> Entries) : KnowledgeBaseEntry;
    public sealed record MissingEntryPlaceholder(string Placeholder = "") : KnowledgeBaseEntry;
}