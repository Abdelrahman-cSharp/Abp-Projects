using Quizzes.Samples;
using Xunit;

namespace Quizzes.EntityFrameworkCore.Applications;

[Collection(QuizzesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<QuizzesEntityFrameworkCoreTestModule>
{

}
