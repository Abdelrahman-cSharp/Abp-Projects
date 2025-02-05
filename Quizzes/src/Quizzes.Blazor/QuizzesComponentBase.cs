using Quizzes.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Quizzes.Blazor;

public abstract class QuizzesComponentBase : AbpComponentBase
{
    protected QuizzesComponentBase()
    {
        LocalizationResource = typeof(QuizzesResource);
    }
}
