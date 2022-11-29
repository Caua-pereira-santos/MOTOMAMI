using Microsoft.EntityFrameworkCore;

namespace MOTOMAMI.Models;

public class MOTOMAMIContext : DbContext
{
    public DbSet<Musica> Musicas { get; set; }

    public DbSet<Album> Albuns { get; set; }

    public DbSet<Gravadora> Gravadoras  {get; set; }

    public DbSet<Evento> Eventos { get; set; }
    
    public DbSet<Instrumento> Instrumentos { get; set; } 

    public DbSet<Ouvinte> Ouvintes { get; set; }


    public MOTOMAMIContext(DbContextOptions<MOTOMAMIContext> options) : base(options)
    {}
}