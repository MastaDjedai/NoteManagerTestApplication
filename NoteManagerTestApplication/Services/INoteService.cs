using NoteManagerTestApplication.Models;

namespace NoteManagerTestApplication.Services;

public interface INoteService
{
    IReadOnlyCollection<Note> GetAll();
    Note? GetById(Guid id);
    Note Create(NoteRequest request);
    Note? Update(Guid id, NoteRequest request);
    bool Delete(Guid id);
}
