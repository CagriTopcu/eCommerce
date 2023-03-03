using eCommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace eCommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(eCommerceEntityFrameworkCoreModule),
    typeof(eCommerceApplicationContractsModule)
    )]
public class eCommerceDbMigratorModule : AbpModule
{

}
