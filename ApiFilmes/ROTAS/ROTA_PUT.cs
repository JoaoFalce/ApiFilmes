public static class Rota_PUT // Define uma classe estática para agrupar as rotas PUT
{

    public static void MapPutRoutes(this WebApplication app)
    {
       
        app.MapPut("/api/filmes/{id}", async (int id, Filme filmeAtualizado, FilmesContext context) =>
        {
            
            var filme = await context.Filmes.FindAsync(id);

          
            if (filme is null)
            {
                return Results.NotFound();
            }

        
            filme.Titulo = filmeAtualizado.Titulo;
            filme.Diretor = filmeAtualizado.Diretor;
            filme.DataLancamento = filmeAtualizado.DataLancamento;
            filme.Genero = filmeAtualizado.Genero;
            filme.Sinopse = filmeAtualizado.Sinopse;

            
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
