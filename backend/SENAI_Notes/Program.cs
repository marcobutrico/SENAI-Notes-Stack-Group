using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Avisa que a aplicacao usa controllers
builder.Services.AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });
    
    
    
   

// Adiciono o Gerador de Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SenaiNotesContext>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteTagRepository, NoteTagRepository>();
builder.Services.AddScoped<INoteUserRepository, NoteUserRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "minhasOrigens",
            policy =>
            {
                policy.WithOrigins("");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }
           );
    
    });

var app = builder.Build();

app.UseCors("minhasOrigens");

// Avisa o .NET que eu tenho Controladores
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
