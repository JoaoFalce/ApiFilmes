using Microsoft.EntityFrameworkCore;

public static class Rota_POST
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
