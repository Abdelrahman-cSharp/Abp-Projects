using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Quizzes.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class QuizzesDbContextFactory : IDesignTimeDbContextFactory<QuizzesDbContext>
{
    public QuizzesDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        QuizzesEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<QuizzesDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new QuizzesDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Quizzes.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
