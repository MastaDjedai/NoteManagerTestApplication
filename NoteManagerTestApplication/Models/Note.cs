namespace NoteManagerTestApplication.Models;

public sealed class Note
{
    public Guid Id { get; init; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
