public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        // Mapeia a rota HTTP DELETE para remover um filme pelo ID
        app.MapDelete("/api/filmes/{id}", async (int id, FilmesContext context) =>
        {
            // Busca o filme pelo id no banco de dados
            var filme = await context.Filmes.FindAsync(id);
            // Se não encontrar o filme, retorna 404 Not Found
            if (filme is null)
                return Results.NotFound();

            // Remove o filme do banco de dados
            context.Filmes.Remove(filme);
            // Salva as alterações de forma assíncrona
            await context.SaveChangesAsync();
            // Retorna 204 No Content
            return Results.NoContent();
        });
    }
}