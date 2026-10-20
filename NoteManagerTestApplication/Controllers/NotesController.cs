using Microsoft.AspNetCore.Mvc;
using NoteManagerTestApplication.Models;
using NoteManagerTestApplication.Services;

namespace NoteManagerTestApplication.Controllers;

[ApiController]
[Route("notes")]
public sealed class NotesController(INoteService noteService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyCollection<Note>> GetAll() => Ok(noteService.GetAll());

    [HttpGet("{id:guid}")]
    public ActionResult<Note> GetById(Guid id)
    {
        var note = noteService.GetById(id);
        return note is null ? NotFound() : Ok(note);
    }

    [HttpPost]
    public ActionResult<Note> Create(NoteRequest request)
    {
        var note = noteService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Note> Update(Guid id, NoteRequest request)
    {
        var note = noteService.Update(id, request);
        return note is null ? NotFound() : Ok(note);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id) => noteService.Delete(id) ? NoContent() : NotFound();
}
