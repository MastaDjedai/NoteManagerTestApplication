using NoteManagerTestApplication.Models;

namespace NoteManagerTestApplication.Repositories;

public interface INoteRepository
{
    IReadOnlyCollection<Note> GetAll();
    Note? GetById(Guid id);
    Note Add(Note note);
    bool Update(Note note);
    bool Delete(Guid id);
}
