using Xunit;

namespace Quizzes.EntityFrameworkCore;

[CollectionDefinition(QuizzesTestConsts.CollectionDefinitionName)]
public class QuizzesEntityFrameworkCoreCollection : ICollectionFixture<QuizzesEntityFrameworkCoreFixture>
{

}
