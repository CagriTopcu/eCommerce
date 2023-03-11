using Volo.Abp;

namespace eCommerce.Discounts;

public class DiscountNameAlreadyExistsException : BusinessException
{
    public DiscountNameAlreadyExistsException(string name)
        : base(eCommerceDomainErrorCodes.DiscountAlreadyExists)
    {
        WithData("name", name);
    }
}
