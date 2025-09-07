using System;
using System.Linq;
using ConsoleApp.Infra;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

class Program
{
    public const string ConnectioString = "Server=localhost;Port=5432;Database=ef-core-playground;User Id=postgres;Password=123456;";
    static void Main(string[] args)
    {
        Console.WriteLine(".:: EF Core Playground ::.");

        var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
        optionsBuilder.UseNpgsql(ConnectioString);
        optionsBuilder.LogTo(Console.WriteLine);

        using var conn = new SampleContext(optionsBuilder.Options);
        conn.Database.Migrate();

        var query = conn.Fretes
            .Where(x => x.Remetente.Cidade.UF == "SC")
            .OrderByDescending(x => x.Valor)
            .Select(x => new
            {
                x.Id,
                x.Valor,
                NomeRemetente = x.Remetente.Nome,
                NomeDestinatario = x.Destinatario.Nome,
                CidadeRemente = x.Remetente.Cidade.Nome,
                CidadeDestinatario = x.Destinatario.Cidade.Nome
            })
            .Take(10)
            .Skip(30) ;
        var fretes = query.AsNoTracking().ToList();

        Console.WriteLine("Fim");
    }
}