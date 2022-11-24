using Microsoft.EntityFrameworkCore;

namespace MOTOMAMI.Models;

public class MOTOMAMIContext : DbContext
{
    public DbSet<Musica> Musicas { get; set; }

    public MOTOMAMIContext(DbContextOptions<MOTOMAMIContext> options) : base(options)
    {}
}