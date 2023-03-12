using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace eCommerce.Products;

public class ProductManager : DomainService
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> CreateAsync(
        [NotNull] string name,
        [NotNull] string shortDescription,
        [NotNull] string fullDescription,
        [NotNull] decimal price,
        [NotNull] int stock,
        [NotNull] Guid categoryId)
    {
        Product existingProduct = await _productRepository.FindByNameAsync(name);

        if (existingProduct is not null)
            throw new ProductAlreadyExistsException(name);

        return new(
            GuidGenerator.Create(),
            name,
            shortDescription,
            fullDescription,
            price,
            stock,
            categoryId);
    }

    public async Task ChangeNameAsync(
        [NotNull] Product product,
        [NotNull] string newName)
    {
        Check.NotNull(product, nameof(product));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        Product existingProduct = await _productRepository.FindByNameAsync(newName);

        if (existingProduct is not null && existingProduct.Id != product.Id)
            throw new ProductAlreadyExistsException(newName);

        product.ChangeName(newName);
    }
}
