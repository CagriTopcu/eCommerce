using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Products;

public interface IProductRepository : IRepository<Product, Guid>
{
    Task<Product> FindByNameAsync(string name);
    Task<List<Product>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null);
}
