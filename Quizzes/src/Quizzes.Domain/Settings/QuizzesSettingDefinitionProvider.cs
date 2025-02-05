using Volo.Abp.Settings;

namespace Quizzes.Settings;

public class QuizzesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(QuizzesSettings.MySetting1));
    }
}
