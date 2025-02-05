using Quizzes.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Quizzes.Permissions;

public class QuizzesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QuizzesPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(QuizzesPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QuizzesResource>(name);
    }
}
