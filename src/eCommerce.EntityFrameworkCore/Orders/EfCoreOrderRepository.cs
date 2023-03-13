using eCommerce.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace eCommerce.Orders;

public class EfCoreOrderRepository
    : EfCoreRepository<eCommerceDbContext, Order, Guid>,
    IOrderRepository
{
    public EfCoreOrderRepository(IDbContextProvider<eCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Order> FindByOrderNoAsync(string orderNo)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(order => order.OrderNo == orderNo);
    }

    public async Task<List<Order>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                order => order.OrderNo.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
    }
}
