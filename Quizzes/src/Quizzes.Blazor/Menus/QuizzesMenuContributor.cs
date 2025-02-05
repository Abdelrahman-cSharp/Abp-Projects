using Quizzes.Localization;
using Quizzes.MultiTenancy;
using System.Threading.Tasks;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Quizzes.Blazor.Menus;

public class QuizzesMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<QuizzesResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                QuizzesMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Quizzes",
                "Quizzes",
                url: "/quizzes",
                icon: "fas fa-book",
                order: 2
            )
        );



        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 4;

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        /*else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }*/

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
