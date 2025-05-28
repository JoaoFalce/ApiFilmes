using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FilmesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//mensagem para mostrar se está rodando certinho no localhost:5200
app.MapGet("/", () => "API de Filmes rodando!");

// Registrar rotas minimal API
Console.WriteLine("Registrando rotas GET...");
Rota_GET.MapGetRoutes(app);
Rota_POST.MapPostRoutes(app);
Rota_DELETE.MapDeleteRoutes(app);
Rota_PUT.MapPutRoutes(app);

app.Run();
