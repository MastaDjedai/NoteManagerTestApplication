# Note Manager API

ASP.NET Core API for managing notes. Notes are stored in memory and are cleared when the service stops.

## Run the API

From the directory containing `NoteManagerTestApplication.csproj`, run:

```bash
dotnet run
```

The console prints the local HTTP/HTTPS URLs. You can also launch with a chosen URL:

```bash
dotnet run --urls http://localhost:5071
```

## Endpoints

| Method | Route | Description |
| --- | --- | --- |
| GET | `/notes` | Return all notes |
| GET | `/notes/{id}` | Return one note by GUID |
| POST | `/notes` | Create a note |
| PUT | `/notes/{id}` | Replace a note's title and content |
| DELETE | `/notes/{id}` | Delete a note |

Create and update requests use JSON with a required `title` (up to 200 characters) and `content`:

```json
{
  "title": "Example",
  "content": "Note text"
}
```

`POST` returns `201 Created` with the created note; missing IDs return `404 Not Found`; successful deletes return `204 No Content`.
