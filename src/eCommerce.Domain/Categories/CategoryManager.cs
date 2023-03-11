using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace eCommerce.Categories;

public class CategoryManager : DomainService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> CreateAsync(
        [NotNull] string name, 
        [NotNull] string description)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotNullOrWhiteSpace(description, nameof(description));

        var existingCategory = await _categoryRepository.FindByNameAsync(name);

        if (existingCategory is not null)
            throw new CategoryAlreadyExistsException(name);

        return new(
            GuidGenerator.Create(),
            name,
            description
        );
    }

    public async Task ChangeNameAsync(
        [NotNull] Category category,
        [NotNull] string newName)
    {
        Check.NotNull(category, nameof(category));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingCategory = await _categoryRepository.FindByNameAsync(newName);

        if (existingCategory is not null && existingCategory.Id != category.Id)
            throw new CategoryAlreadyExistsException(newName);

        category.ChangeName(newName);
    }

}
