using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Stores;

public interface IStoreRepository : IRepository<Store, Guid>
{
    Task<Store> FindByNameAsync(string name);
    Task<Store> FindByUrlAsync(string url);
    Task<List<Store>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null);
}
