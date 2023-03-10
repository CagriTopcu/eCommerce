using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Products;

public class ProductAppService : eCommerceAppService, IProductAppService
{
    private readonly IProductRepository _productAppRepository;
    private readonly ProductManager _productManager;

    public ProductAppService(IProductRepository productAppRepository, ProductManager productManager)
    {
        _productAppRepository = productAppRepository;
        _productManager = productManager;
    }

    public Task<ProductDto> CreateAsync(CreateProductDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateProductDto input)
    {
        throw new NotImplementedException();
    }
}
