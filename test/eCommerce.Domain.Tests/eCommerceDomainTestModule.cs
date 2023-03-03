using eCommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace eCommerce;

[DependsOn(
    typeof(eCommerceEntityFrameworkCoreTestModule)
    )]
public class eCommerceDomainTestModule : AbpModule
{

}
