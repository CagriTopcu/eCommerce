using Volo.Abp;

namespace eCommerce.Products;

public class ProductAlreadyExistsException : BusinessException
{
    public ProductAlreadyExistsException(string name)
        : base(eCommerceDomainErrorCodes.ProductAlreadyExists)
    {
        WithData("name", name);
    }
}
