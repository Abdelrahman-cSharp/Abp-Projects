using Quizzes.Localization;
using Volo.Abp.Application.Services;

namespace Quizzes;

/* Inherit your application services from this class.
 */
public abstract class QuizzesAppService : ApplicationService
{
    protected QuizzesAppService()
    {
        LocalizationResource = typeof(QuizzesResource);
    }
}
