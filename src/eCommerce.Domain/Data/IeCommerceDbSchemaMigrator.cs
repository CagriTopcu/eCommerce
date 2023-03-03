using System.Threading.Tasks;

namespace eCommerce.Data;

public interface IeCommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
