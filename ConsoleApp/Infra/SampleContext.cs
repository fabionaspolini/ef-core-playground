using ConsoleApp.Domain;
using ConsoleApp.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Infra;

public class SampleContext : DbContext
{
    protected SampleContext()
    {
    }
        
    public SampleContext(DbContextOptions<SampleContext> options) : base(options)
    {
    }

    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Frete> Fretes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CidadeMap());
        modelBuilder.ApplyConfiguration(new ClienteMap());
        modelBuilder.ApplyConfiguration(new FreteMap());
    }
}