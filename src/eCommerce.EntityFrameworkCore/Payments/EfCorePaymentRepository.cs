using eCommerce.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace eCommerce.Payments;

public class EfCorePaymentRepository
    : EfCoreRepository<eCommerceDbContext, Payment, Guid>,
    IPaymentRepository
{
    public EfCorePaymentRepository(IDbContextProvider<eCommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Payment> FindByOrderIdAsync(Guid orderId)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(payment => payment.OrderId == orderId);
    }

    public async Task<List<Payment>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                payment => payment.CreationTime.ToString().Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
    }
}
