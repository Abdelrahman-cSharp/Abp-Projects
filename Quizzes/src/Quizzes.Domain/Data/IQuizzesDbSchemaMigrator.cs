using System.Threading.Tasks;

namespace Quizzes.Data;

public interface IQuizzesDbSchemaMigrator
{
    Task MigrateAsync();
}
