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
         
            await context.SaveChangesAsync();
           
            return Results.NoContent();
        });
    }
}
