using Microsoft.EntityFrameworkCore;

public class FilmesContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    public FilmesContext(DbContextOptions<FilmesContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Filme>()
            .Property(f => f.Titulo)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Filme>()
            .Property(f => f.Genero)
            .HasMaxLength(50);

        modelBuilder.Entity<Filme>()
            .Property(f => f.Diretor)
            .HasMaxLength(100);
    }
}
