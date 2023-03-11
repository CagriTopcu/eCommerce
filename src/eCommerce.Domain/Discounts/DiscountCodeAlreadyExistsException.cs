using Volo.Abp;

namespace eCommerce.Discounts;

public class DiscountCodeAlreadyExistsException : BusinessException
{
    public DiscountCodeAlreadyExistsException(string code)
        : base(eCommerceDomainErrorCodes.DiscountAlreadyExists)
    {
        WithData("code", code);
    }
}
