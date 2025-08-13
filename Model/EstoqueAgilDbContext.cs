using EstoqueAgil.model;
using Microsoft.EntityFrameworkCore;
namespace EstoqueAgil.model;

public class EstoqueAgilDbContext : DbContext
{

    public EstoqueAgilDbContext(DbContextOptions<EstoqueAgilDbContext> options)
        : base(options) { }

    public DbSet<Produto> Produto { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
}