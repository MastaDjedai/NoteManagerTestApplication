using System.ComponentModel.DataAnnotations;

namespace NoteManagerTestApplication.Models;

public sealed class NoteRequest
{
    [Required]
    [StringLength(200)]
    public string Title { get; init; } = string.Empty;

    [Required]
    public string Content { get; init; } = string.Empty;
}
