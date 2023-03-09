using Volo.Abp;

namespace eCommerce.Discounts;

public class DiscountAlreadyExistsException : BusinessException
{
    public DiscountAlreadyExistsException(string name)
        : base(eCommerceDomainErrorCodes.DiscountAlreadyExists)
    {
        WithData("name", name);
    }
}
