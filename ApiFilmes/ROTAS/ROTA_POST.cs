using Microsoft.EntityFrameworkCore; // Importa o EF Core para manipulação do banco de dados

public static class Rota_POST // Classe estática para agrupar as rotas POST
{
    // Método de extensão para registrar as rotas POST na aplicação
    public static void MapPostRoutes(this WebApplication app)
    {
        // Mapeia a rota HTTP POST para criar um novo filme
        app.MapPost("/api/filmes", async (Filme filme, FilmesContext context) =>
        {
            // Adiciona o novo filme recebido no corpo da requisição ao banco de dados
            context.Filmes.Add(filme);
            // Salva as alterações de forma assíncrona
            await context.SaveChangesAsync();

            // Retorna 201 Created com a URL do novo filme e o objeto criado
            return Results.Created($"/filmes/{filme.Id}", filme);
        });
    }
}