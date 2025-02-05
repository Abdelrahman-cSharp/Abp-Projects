using Volo.Abp.Modularity;

namespace Quizzes;

[DependsOn(
    typeof(QuizzesApplicationModule),
    typeof(QuizzesDomainTestModule)
)]
public class QuizzesApplicationTestModule : AbpModule
{

}
