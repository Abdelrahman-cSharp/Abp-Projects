using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Quizzes.Data;

/* This is used if database provider does't define
 * IQuizzesDbSchemaMigrator implementation.
 */
public class NullQuizzesDbSchemaMigrator : IQuizzesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
