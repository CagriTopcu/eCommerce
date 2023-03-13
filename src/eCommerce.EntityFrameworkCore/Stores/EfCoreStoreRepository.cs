using eCommerce.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace eCommerce.Stores;

public class EfCoreStoreRepository
    : EfCoreRepository<eCommerceDbContext, Store, Guid>,
    IStoreRepository
{
    public EfCoreStoreRepository(IDbContextProvider<eCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Store> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(store => store.Name == name);
    }

    public async Task<Store> FindByUrlAsync(string url)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(store => store.Url == url);
    }

    public async Task<List<Store>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                store => store.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
    }
}
