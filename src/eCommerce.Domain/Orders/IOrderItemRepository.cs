using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Orders;

public interface IOrderItemRepository : IRepository<OrderItem, Guid>
{
    Task<List<OrderItem>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null);
}
