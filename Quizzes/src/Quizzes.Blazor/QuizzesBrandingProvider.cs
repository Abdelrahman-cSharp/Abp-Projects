using Microsoft.Extensions.Localization;
using Quizzes.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Quizzes.Blazor;

[Dependency(ReplaceServices = true)]
public class QuizzesBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<QuizzesResource> _localizer;

    public QuizzesBrandingProvider(IStringLocalizer<QuizzesResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
