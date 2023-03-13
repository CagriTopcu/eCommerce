using eCommerce.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace eCommerce.Discounts;

public class EfCoreDiscountRepository
    : EfCoreRepository<eCommerceDbContext, Discount, Guid>,
    IDiscountRepository
{
    public EfCoreDiscountRepository(IDbContextProvider<eCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Discount> FindByCodeAsync(string code)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(discount => discount.Code == code);
    }

    public async Task<Discount> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(discount => discount.Name == name);
    }

    public async Task<List<Discount>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                discount => discount.Name.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
    }
}
