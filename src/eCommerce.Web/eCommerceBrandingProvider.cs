using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace eCommerce.Web;

[Dependency(ReplaceServices = true)]
public class eCommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "eCommerce";
}
