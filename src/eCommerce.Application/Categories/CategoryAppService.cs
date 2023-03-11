using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

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

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
    {
        var category = await _categoryManager.CreateAsync(
            input.Name,
            input.Description);

        await _categoryRepository.InsertAsync(category);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }

    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return ObjectMapper.Map<Category, CategoryDto>(category);
    }

    public async Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Category.Name);
        }

        var categories = await _categoryRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _categoryRepository.CountAsync()
            : await _categoryRepository.CountAsync(
                category => category.Name.Contains(input.Filter));

        return new PagedResultDto<CategoryDto>(
            totalCount,
            ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories)
        );
    }

    public async Task UpdateAsync(Guid id, UpdateCategoryDto input)
    {
        var category = await _categoryRepository.GetAsync(id);

        await _categoryManager.ChangeNameAsync(category, input.Name);
        category.ChangeDescription(input.Description);

        await _categoryRepository.UpdateAsync(category);
    }
}
