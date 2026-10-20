using System.Collections.Concurrent;
using NoteManagerTestApplication.Models;

namespace NoteManagerTestApplication.Repositories;

public sealed class InMemoryNoteRepository : INoteRepository
{
    private readonly ConcurrentDictionary<Guid, Note> _notes = new();

    public IReadOnlyCollection<Note> GetAll() => _notes.Values.ToArray();

    public Note? GetById(Guid id) => _notes.GetValueOrDefault(id);

    public Note Add(Note note)
    {
        _notes[note.Id] = note;
        return note;
    }

    public bool Update(Note note)
    {
        if (!_notes.ContainsKey(note.Id))
        {
            return false;
        }

        _notes[note.Id] = note;
        return true;
    }

    public bool Delete(Guid id) => _notes.TryRemove(id, out _);
}
