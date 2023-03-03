using eCommerce.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace eCommerce.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class eCommercePageModel : AbpPageModel
{
    protected eCommercePageModel()
    {
        LocalizationResourceType = typeof(eCommerceResource);
    }
}
