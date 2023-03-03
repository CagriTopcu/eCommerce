using System;
using System.Collections.Generic;
using System.Text;
using eCommerce.Localization;
using Volo.Abp.Application.Services;

namespace eCommerce;

/* Inherit your application services from this class.
 */
public abstract class eCommerceAppService : ApplicationService
{
    protected eCommerceAppService()
    {
        LocalizationResource = typeof(eCommerceResource);
    }
}
