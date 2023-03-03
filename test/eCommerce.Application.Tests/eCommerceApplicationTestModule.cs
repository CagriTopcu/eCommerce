using Volo.Abp.Modularity;

namespace eCommerce;

[DependsOn(
    typeof(eCommerceApplicationModule),
    typeof(eCommerceDomainTestModule)
    )]
public class eCommerceApplicationTestModule : AbpModule
{

}
