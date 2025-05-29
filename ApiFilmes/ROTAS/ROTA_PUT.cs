public static class Rota_PUT // Define uma classe estática para agrupar as rotas PUT
{
    // Método de extensão para registrar as rotas PUT na aplicação
    public static void MapPutRoutes(this WebApplication app)
    {
        // Mapeia a rota HTTP PUT para atualizar um filme pelo ID
        app.MapPut("/api/filmes/{id}", async (int id, Filme filmeAtualizado, FilmesContext context) =>
        {
            // Busca o filme no banco pelo ID informado na URL
            var filme = await context.Filmes.FindAsync(id);

            // Se não encontrar o filme, retorna 404 Not Found
            if (filme is null)
            {
                return Results.NotFound();
            }

            // Atualiza os campos do filme com os dados recebidos no corpo da requisição
            filme.Titulo = filmeAtualizado.Titulo;
            filme.Diretor = filmeAtualizado.Diretor;
            filme.DataLancamento = filmeAtualizado.DataLancamento;
            filme.Genero = filmeAtualizado.Genero;
            filme.Sinopse = filmeAtualizado.Sinopse;

            // Salva as alterações no banco de dados de forma assíncrona
            await context.SaveChangesAsync();

            // Retorna 204 No Content indicando sucesso sem conteúdo no corpo da resposta
            return Results.NoContent();
        });
    }
}