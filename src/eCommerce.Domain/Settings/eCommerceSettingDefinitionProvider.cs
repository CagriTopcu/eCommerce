using Volo.Abp.Settings;

namespace eCommerce.Settings;

public class eCommerceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(eCommerceSettings.MySetting1));
    }
}
