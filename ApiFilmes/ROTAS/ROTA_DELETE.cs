public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
      
        app.MapDelete("/api/filmes/{id}", async (int id, FilmesContext context) =>
        {
   
            var filme = await context.Filmes.FindAsync(id);
            // Se não encontrar o filme, retorna 404 Not Found
            if (filme is null)
                return Results.NotFound();

            
            context.Filmes.Remove(filme);
            // Salva as alterações de forma assíncrona
            await context.SaveChangesAsync();
            // Retorna 204 No Content
            return Results.NoContent();
        });
    }
}
