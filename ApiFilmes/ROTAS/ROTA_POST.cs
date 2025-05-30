using Microsoft.EntityFrameworkCore; // Importa o EF Core para manipulação do banco de dados

public static class Rota_POST // Classe estática para agrupar as rotas POST
{

    public static void MapPostRoutes(this WebApplication app)
    {
     
        app.MapPost("/api/filmes", async (Filme filme, FilmesContext context) =>
        {
           
            context.Filmes.Add(filme);
           
            await context.SaveChangesAsync();

            return Results.Created($"/filmes/{filme.Id}", filme);
        });
    }
}
