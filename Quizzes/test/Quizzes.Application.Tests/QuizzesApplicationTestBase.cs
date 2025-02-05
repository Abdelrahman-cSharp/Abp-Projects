using Volo.Abp.Modularity;

namespace Quizzes;

public abstract class QuizzesApplicationTestBase<TStartupModule> : QuizzesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
