using EstoqueAgil.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAgil.Contexts;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Produto> produtos { get; set; }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Categoria)
            .HasConversion<string>();
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Produto>().ToTable("Produtos");
    }
}