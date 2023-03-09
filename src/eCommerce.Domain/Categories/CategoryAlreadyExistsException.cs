using Volo.Abp;

namespace eCommerce.Categories;

public class CategoryAlreadyExistsException : BusinessException
{
    public CategoryAlreadyExistsException(string name)
        : base(eCommerceDomainErrorCodes.CategoryAlreadyExists)
    {
        WithData("name", name);
    }
}
