using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<FilmesContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthorization();

var app = builder.Build();

// garante que o banco e as tabelas existem
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FilmesContext>();
    db.Database.EnsureCreated();

    if (!db.Filmes.Any())
    {
        db.Filmes.AddRange(
                new Filme { Titulo = "O Senhor dos Anéis", Sinopse = "Uma aventura épica.", DataLancamento = new DateTime(2001, 12, 19), Genero = "Fantasia", Diretor = "Peter Jackson" },

                new Filme { Titulo = "Matrix", Sinopse = "Realidade simulada.", DataLancamento = new DateTime(1999, 3, 31), Genero = "Ficção Científica", Diretor = "Wachowski" },

                new Filme { Titulo = "Interestelar", Sinopse = "Viagem espacial.", DataLancamento = new DateTime(2014, 11, 6), Genero = "Ficção Científica", Diretor = "Christopher Nolan" },

                new Filme { Titulo = "Forrest Gump", Sinopse = "A vida de um homem simples que testemunha grandes eventos.", DataLancamento = new DateTime(1994, 7, 6), Genero = "Drama", Diretor = "Robert Zemeckis" },

                new Filme { Titulo = "Gladiador", Sinopse = "Um general romano busca vingança.", DataLancamento = new DateTime(2000, 5, 5), Genero = "Ação", Diretor = "Ridley Scott" },

                new Filme { Titulo = "A Origem", Sinopse = "Um ladrão invade sonhos para roubar segredos.", DataLancamento = new DateTime(2010, 7, 16), Genero = "Ação", Diretor = "Christopher Nolan" },

                new Filme { Titulo = "Pulp Fiction", Sinopse = "Histórias interligadas de crime em Los Angeles.", DataLancamento = new DateTime(1994, 10, 14), Genero = "Crime", Diretor = "Quentin Tarantino" },

                new Filme { Titulo = "O Poderoso Chefão", Sinopse = "A saga da família mafiosa Corleone.", DataLancamento = new DateTime(1972, 3, 24), Genero = "Crime", Diretor = "Francis Ford Coppola" },

                new Filme { Titulo = "Clube da Luta", Sinopse = "Um homem insatisfeito forma um clube secreto de lutas.", DataLancamento = new DateTime(1999, 10, 15), Genero = "Drama", Diretor = "David Fincher" },

                new Filme { Titulo = "Vingadores: Ultimato", Sinopse = "Os heróis se unem para derrotar Thanos.", DataLancamento = new DateTime(2019, 4, 26), Genero = "Ação", Diretor = "Anthony Russo, Joe Russo" }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//mensagem para mostrar se está rodando certinho no localhost:5200
app.MapGet("/", () => "API de Filmes rodando! Abra http://localhost:5200/swagger/index.html para visualizar as Apis!!!");

// Registrar rotas API
Console.WriteLine("Registrando rotas GET...");
Rota_GET.MapGetRoutes(app);
Rota_POST.MapPostRoutes(app);
Rota_DELETE.MapDeleteRoutes(app);
Rota_PUT.MapPutRoutes(app);

app.Run();