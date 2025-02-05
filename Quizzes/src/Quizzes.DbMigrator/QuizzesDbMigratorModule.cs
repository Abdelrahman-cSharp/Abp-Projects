using Quizzes.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Quizzes.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QuizzesEntityFrameworkCoreModule),
    typeof(QuizzesApplicationContractsModule)
)]
public class QuizzesDbMigratorModule : AbpModule
{
}
