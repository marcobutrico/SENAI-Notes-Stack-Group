using Microsoft.IdentityModel.Tokens;
using System.Text;
using SENAI_Notes.Context;
using SENAI_Notes.Interfaces;
using SENAI_Notes.Repositories;
using SENAI_Notes.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Avisa que a aplicacao usa controllers
builder.Services.AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });

// Adiciono o Gerador de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});


builder.Services.AddDbContext<SenaiNotesContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteUserRepository, NoteUserRepository>();


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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nossa-chave-secreta-mega-master-ultra-segura-stack-group-senai"))
        };
    });


builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "minhasOrigens",
            policy =>
            {
                //Alterado link para o Frontend
                policy.WithOrigins("http://localhost:7279", "http://127.0.0.1:7279");
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


app.UseStaticFiles();

var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

if (!Directory.Exists(pastaDestino))
    Directory.CreateDirectory(pastaDestino);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
    RequestPath = "/imagens"
});


app.Run();
