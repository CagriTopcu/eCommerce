using Volo.Abp;

namespace eCommerce.Stores;

public class StoreUrlAlreadyExistsException : BusinessException
{
    public StoreUrlAlreadyExistsException(string url)
        : base(eCommerceDomainErrorCodes.StoreUrlAlreadyExists)
    {
        WithData("url", url);
    }
}
