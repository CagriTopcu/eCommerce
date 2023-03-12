using Volo.Abp;

namespace eCommerce.Stores;

public class StoreNotFoundException : BusinessException
{
    public StoreNotFoundException()
        : base(eCommerceDomainErrorCodes.StoreNotFound)
    {
    }
}
