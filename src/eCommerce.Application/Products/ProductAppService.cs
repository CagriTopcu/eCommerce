using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Products;

public class ProductAppService : eCommerceAppService, IProductAppService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductManager _productManager;

    public ProductAppService(IProductRepository productRepository, ProductManager productManager)
    {
        _productRepository = productRepository;
        _productManager = productManager;
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto input)
    {
        Product product = await _productManager.CreateAsync(
            input.Name,
            input.ShortDescription,
            input.FullDescription,
            input.Price,
            input.Stock,
            input.CategoryId);

        await _productRepository.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        Product product = await _productRepository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Product.Name);
        }

        List<Product> products = await _productRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        int totalCount = input.Filter == null
            ? await _productRepository.CountAsync()
            : await _productRepository.CountAsync(
                product => product.Name.Contains(input.Filter));

        return new PagedResultDto<ProductDto>(
            totalCount,
            ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
        );
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto input)
    {
        Product existingProduct = await _productRepository.GetAsync(id);

        await _productManager.ChangeNameAsync(existingProduct, input.Name);

        Product product = new(
            id,
            existingProduct.Name,
            input.ShortDescription,
            input.FullDescription,
            input.Price,
            input.Stock,
            input.CategoryId);

        await _productRepository.UpdateAsync(product);
    }
}
