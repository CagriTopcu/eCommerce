using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace eCommerce.Data;

/* This is used if database provider does't define
 * IeCommerceDbSchemaMigrator implementation.
 */
public class NulleCommerceDbSchemaMigrator : IeCommerceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
