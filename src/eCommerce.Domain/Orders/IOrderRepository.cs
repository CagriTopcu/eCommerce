using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<List<Order>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null);
    }
}
