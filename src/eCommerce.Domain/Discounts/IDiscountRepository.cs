using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Discounts;

public interface IDiscountRepository : IRepository<Discount, Guid>
{
    Task<Discount> FindByNameAsync(string name);
    Task<Discount> FindByCodeAsync(string code);
    Task<List<Discount>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null);
}
