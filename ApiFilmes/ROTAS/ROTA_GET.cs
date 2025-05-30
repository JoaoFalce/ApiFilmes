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

    
        app.MapGet("/api/filmes/genero/{genero}", async (string genero, FilmesContext context) =>
        {
          o
            var filmes = await context.Filmes
                .Where(f => f.Genero.ToLower().Contains(genero.ToLower()))
                .ToListAsync();

           
            return Results.Ok(filmes);
        });

    
        app.MapGet("/api/filmes/genero/{genero}/count", async (string genero, FilmesContext context) =>
        {
            var quantidade = await context.Filmes
                .CountAsync(f => f.Genero.ToLower().Contains(genero.ToLower()));

            return Results.Ok(new { Genero = genero, Quantidade = quantidade });
        });

    
        app.MapGet("/api/filmes/diretor/{diretor}", async (string diretor, FilmesContext context) =>
        {
            
            var filmes = await context.Filmes
                .Where(f => f.Diretor.ToLower().Contains(diretor.ToLower()))
                .ToListAsync();

          
            return Results.Ok(filmes);
        });

        
        app.MapGet("/api/filmes/diretor/{diretor}/count", async (string diretor, FilmesContext context) =>
        {
            var quantidade = await context.Filmes
                .CountAsync(f => f.Diretor.ToLower().Contains(diretor.ToLower()));

            return Results.Ok(new { Diretor = diretor, Quantidade = quantidade });
        });
    
        
        app.MapGet("/api/filmes/{id}", async (int id, FilmesContext context) =>
        {
           
            var filme = await context.Filmes.FindAsync(id);
          
            return filme is not null ? Results.Ok(filme) : Results.NotFound();
        });
    }
       

}
