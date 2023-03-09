using Volo.Abp;

namespace eCommerce.Stores;

public class StoreAlreadyExistsException : BusinessException
{
    public StoreAlreadyExistsException(string name)
        : base(eCommerceDomainErrorCodes.StoreAlreadyExists)
    {
        WithData("name", name);
    }
}
