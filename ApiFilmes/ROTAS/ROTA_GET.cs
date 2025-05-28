using Microsoft.EntityFrameworkCore;
public static class Rota_GET
{
    public static void MapGetRoutes(this WebApplication app)
    {
        app.MapGet("/api/filmes", async (FilmesContext context) =>
        {
            var filmes = await context.Filmes.ToListAsync();
            return Results.Ok(filmes);
        });

        app.MapGet("/api/filmes/{id}", async (int id, FilmesContext context) =>
        {
            var filme = await context.Filmes.FindAsync(id);
            return filme is not null ? Results.Ok(filme) : Results.NotFound();
        });
    }
}