using Volo.Abp.Modularity;

namespace Quizzes;

/* Inherit from this class for your domain layer tests. */
public abstract class QuizzesDomainTestBase<TStartupModule> : QuizzesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
