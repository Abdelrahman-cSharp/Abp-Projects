using Quizzes.Samples;
using Xunit;

namespace Quizzes.EntityFrameworkCore.Domains;

[Collection(QuizzesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<QuizzesEntityFrameworkCoreTestModule>
{

}
