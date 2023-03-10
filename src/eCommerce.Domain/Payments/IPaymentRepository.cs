using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Payments;

public interface IPaymentRepository : IRepository<Payment, Guid>
{
    Task<Payment> FindByOrderIdAsync(Guid orderId);
    Task<List<Payment>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null);
}
