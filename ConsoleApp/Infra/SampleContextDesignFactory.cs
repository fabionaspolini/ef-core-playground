﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleApp.Infra;

/// <summary>
/// Fábrica para suportar CLI para criar e aplicar migrations, não utilizada em tempo de execução
/// </summary>
public class SampleContextDesignFactory : IDesignTimeDbContextFactory<SampleContext>
{
    public SampleContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
        optionsBuilder.UseNpgsql(Consts.ConnectionString);
        return new SampleContext(optionsBuilder.Options);
    }
}