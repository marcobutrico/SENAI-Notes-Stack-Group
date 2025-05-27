using Microsoft.IdentityModel.Tokens;
using System.Text;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Repositories;
using SENAI_Notes.Services;

var builder = WebApplication.CreateBuilder(args);

// Avisa que a aplicacao usa controllers
builder.Services.AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });

// Adiciono o Gerador de Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

builder.Services.AddDbContext<SenaiNotesContext>();
//builder.Services.AddScoped<INoteRepository, NoteRepository>();

// Ensure that NoteTagRepository implements INoteTagRepository
builder.Services.AddScoped<INoteTagRepository, NoteTagRepository>();
builder.Services.AddScoped<INoteUserRepository, NoteUserRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

// builder.Services.AddScoped<PasswordService, PasswordService>();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "SenaiNotes",
            ValidAudience = "SenaiNotes",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-mega-master-ultra-segura-senai"))
        };
    });


builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "minhasOrigens",
            policy =>
            {
                policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173");
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
