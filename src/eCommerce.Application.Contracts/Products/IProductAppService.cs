using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eCommerce.Products;

public interface IProductAppService : IApplicationService
{
    Task<ProductDto> GetAsync(Guid id);
    Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input);
    Task<ProductDto> CreateAsync(CreateProductDto input);
    Task UpdateAsync(Guid id, UpdateProductDto input);
    Task DeleteAsync(Guid id);
}
