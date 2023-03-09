using Volo.Abp.Domain.Services;

namespace eCommerce.Products;

public class ProductManager : DomainService
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
}
