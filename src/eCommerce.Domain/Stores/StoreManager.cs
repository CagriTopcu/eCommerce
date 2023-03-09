using Volo.Abp.Domain.Services;

namespace eCommerce.Stores;

public class StoreManager : DomainService
{
    private readonly IStoreRepository _storeRepository;

    public StoreManager(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
}
