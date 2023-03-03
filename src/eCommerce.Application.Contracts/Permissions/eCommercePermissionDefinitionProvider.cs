using eCommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace eCommerce.Permissions;

public class eCommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(eCommercePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(eCommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<eCommerceResource>(name);
    }
}
