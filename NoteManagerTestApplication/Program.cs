using NoteManagerTestApplication.Repositories;
using NoteManagerTestApplication.Services;

var builder = WebApplication.CreateBuilder(args);

var angularCorsPolicy = "AllowAngularApp";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: angularCorsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<INoteRepository, InMemoryNoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseCors(angularCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
