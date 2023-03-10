using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Categories;

public class CategoryAppService : eCommerceAppService, ICategoryAppService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryManager _categoryManager;

    public CategoryAppService(ICategoryRepository categoryRepository, CategoryManager categoryManager)
    {
        _categoryRepository = categoryRepository;
        _categoryManager = categoryManager;
    }

    public Task<CategoryDto> CreateAsync(CreateCategoryDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateCategoryDto input)
    {
        throw new NotImplementedException();
    }
}
