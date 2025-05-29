using Microsoft.EntityFrameworkCore;

public static class Rota_GET
{
    public static void MapGetRoutes(this WebApplication app)
    {
        // lista todos os filmes
        app.MapGet("/api/filmes", async (FilmesContext context) =>
        {
            // Busca todos os filmes no banco de dados
            var filmes = await context.Filmes.ToListAsync();
            // lista de filmes com status OK
            return Results.Ok(filmes);
        });

        // lista filmes por gênero 
        app.MapGet("/api/filmes/genero/{genero}", async (string genero, FilmesContext context) =>
        {
            // Busca todos os filmes do genero
            var filmes = await context.Filmes
                .Where(f => f.Genero.ToLower().Contains(genero.ToLower()))
                .ToListAsync();

            // lista de filmes encontrados
            return Results.Ok(filmes);
        });

        // conta quantos filmes tem de um genero
        app.MapGet("/api/filmes/genero/{genero}/count", async (string genero, FilmesContext context) =>
        {
            var quantidade = await context.Filmes
                .CountAsync(f => f.Genero.ToLower().Contains(genero.ToLower()));

            return Results.Ok(new { Genero = genero, Quantidade = quantidade });
        });

        // listar filmes por diretor
        app.MapGet("/api/filmes/diretor/{diretor}", async (string diretor, FilmesContext context) =>
        {
            // Busca todos os filmes que o diretor tem
            var filmes = await context.Filmes
                .Where(f => f.Diretor.ToLower().Contains(diretor.ToLower()))
                .ToListAsync();

            // lista de filmes encontrados
            return Results.Ok(filmes);
        });

        // contar quantos filmes existem de um determinado diretor
        app.MapGet("/api/filmes/diretor/{diretor}/count", async (string diretor, FilmesContext context) =>
        {
            var quantidade = await context.Filmes
                .CountAsync(f => f.Diretor.ToLower().Contains(diretor.ToLower()));

            return Results.Ok(new { Diretor = diretor, Quantidade = quantidade });
        });
    
        // Rota GET para buscar um filme específico pelo ID
        app.MapGet("/api/filmes/{id}", async (int id, FilmesContext context) =>
        {
            // Busca o filme pelo ID no banco de dados
            var filme = await context.Filmes.FindAsync(id);
            // Se encontrou, retorna OK com o filme, senão, retorna 404 Not Found
            return filme is not null ? Results.Ok(filme) : Results.NotFound();
        });
    }
       

}