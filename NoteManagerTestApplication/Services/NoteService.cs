using NoteManagerTestApplication.Models;
using NoteManagerTestApplication.Repositories;

namespace NoteManagerTestApplication.Services;

public sealed class NoteService(INoteRepository repository) : INoteService
{
    public IReadOnlyCollection<Note> GetAll() => repository.GetAll();

    public Note? GetById(Guid id) => repository.GetById(id);

    public Note Create(NoteRequest request) => repository.Add(new Note
    {
        Id = Guid.NewGuid(),
        Title = request.Title,
        Content = request.Content
    });

    public Note? Update(Guid id, NoteRequest request)
    {
        if (repository.GetById(id) is null)
        {
            return null;
        }

        var note = new Note { Id = id, Title = request.Title, Content = request.Content };
        return repository.Update(note) ? note : null;
    }

    public bool Delete(Guid id) => repository.Delete(id);
}
