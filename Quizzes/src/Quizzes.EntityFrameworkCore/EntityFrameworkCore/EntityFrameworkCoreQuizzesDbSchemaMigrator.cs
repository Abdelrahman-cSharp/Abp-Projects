using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quizzes.Data;
using Volo.Abp.DependencyInjection;

namespace Quizzes.EntityFrameworkCore;

public class EntityFrameworkCoreQuizzesDbSchemaMigrator
    : IQuizzesDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreQuizzesDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the QuizzesDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<QuizzesDbContext>()
            .Database
            .MigrateAsync();
    }
}
