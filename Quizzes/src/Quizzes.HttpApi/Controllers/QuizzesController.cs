using Quizzes.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Quizzes.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QuizzesController : AbpControllerBase
{
    protected QuizzesController()
    {
        LocalizationResource = typeof(QuizzesResource);
    }
}
