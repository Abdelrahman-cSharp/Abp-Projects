using Volo.Abp.Modularity;

namespace Quizzes;

[DependsOn(
    typeof(QuizzesDomainModule),
    typeof(QuizzesTestBaseModule)
)]
public class QuizzesDomainTestModule : AbpModule
{

}
